    bool ActivateChromeTab(string title)
    {
	  Process[] procsChrome = Process.GetProcessesByName("chrome");
   	  foreach (Process proc in procsChrome)
	  {
		if (proc.MainWindowHandle == IntPtr.Zero)
		{
			continue;
		}
		AutomationElement root = AutomationElement.FromHandle(proc.MainWindowHandle);
		Condition condNewTab = new PropertyCondition(AutomationElement.NameProperty, "New Tab");
		AutomationElement elmNewTab = root.FindFirst(TreeScope.Descendants, condNewTab);
		TreeWalker treewalker = TreeWalker.ControlViewWalker;
		AutomationElement elmTabStrip = treewalker.GetParent(elmNewTab);
		Condition condTabItem = new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.TabItem);
		var index = 0;
		var tabItems = elmTabStrip.FindAll(TreeScope.Children, condTabItem);
		var coll = new List<AutomationElement>();
		foreach (AutomationElement element in tabItems)
		{
			coll.Add(element);
		}
		bool NameMatch(string name)
		{
			return name == title || name.StartsWith(title + " ");
		}
		
		// short-circuit the search when no searched string cannot be found
		if (!coll.Any(e => NameMatch(e.Current.Name)))
		{
			continue;
		}
		
		var t = new Stopwatch();
		t.Start();
		var withPoints = coll.AsParallel().Select(e =>
		{
			var point = new System.Windows.Point(int.MaxValue, int.MaxValue);
			if (e.TryGetClickablePoint(out point))
			{
			}
			return new
			{
				Name = e.Current.Name,
				Element = e,
				Point = point
			};
		}).OrderBy(e => e.Point.X);
		
		foreach (var tabItem in withPoints)
		{
			index++;
			var name = tabItem.Name;
			if (NameMatch(name))
			{
				SetForegroundWindow(proc.MainWindowHandle); // activate window
				Select(index); // select tab				
				return true;
			}
		}
	  }
	
	  return false;
    }
