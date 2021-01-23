    //1. Find the Html element x and y coordinates with something like this:
 
	var scriptTask = _browser.EvaluateScriptAsync(@"
		var play = document.getElementByClassName('image')[0]
		function findPos(obj)
		{
			var curleft = 0;
			var curtop = 0;
			if (obj.offsetParent)
			{
				do
				{
					curleft += obj.offsetLeft;
					curtop += obj.offsetTop;
				} while (obj = obj.offsetParent);
				return { X: curleft,Y: curtop};
			}
		}
		findPos(play)"
	)
	.ContinueWith(x =>
	{
	// 2. Continue with finding the coordinates and using MouseClick method 
    // for pressing left mouse button down and releasing it at desired end position.
		var responseForMouseClick = x.Result;
		if (responseForMouseClick.Success && responseForMouseClick.Result != null)
		{
			var xy = responseForMouseClick.Result;
			var json = JsonConvert.SerializeObject(xy).ToString();
			var coordx = json.Substring(json.IndexOf(':') + 1, 3);
			var coordy = json.Substring(json.LastIndexOf(':') + 1, 3);
			MouseLeftDown(int.Parse(coordx) + 5, int.Parse(coordy) + 5);
			MouseLeftUp(int.Parse(coordx) + 100, int.Parse(coordy) + 100);
		}
		
	// 3. Repeat the finding of coordinates for making focus with a click. 
    // Use the HitEnter method to send the KeyEvent.
		_browser.EvaluateScriptAsync(@"
			var objForHittingEnter = document
                 .getElementsByClassName('class-name-for-hitting-enter-on')[0]
			         findPos(objForHittingEnter)") // Already defined earlier
		.ContinueWith(y =>
		{
			var responseForEnter = y.Result;
			if (responseForEnter.Success && responseForEnter.Result != null)
			{
				var xy = responseForEnter.Result;
				var json = JsonConvert.SerializeObject(xy).ToString();
				var coordx = json.Substring(json.IndexOf(':') + 1, 3);
				var coordy = json.Substring(json.LastIndexOf(':') + 1, 3);
				HitEnter(int.Parse(coordx) + 2, int.Parse(coordy) + 2);
			}
		});
	});
	
	
	public void MouseLeftDown(int x, int y)
	{
		_browser.GetBrowser().GetHost()
            .SendMouseClickEvent(x, y, MouseButtonType.Left, false, 1, CefEventFlags.None);
		Thread.Sleep(15);
	}
	
	public void MouseLeftUp(int x, int y)
	{
		_browser.GetBrowser().GetHost()
            .SendMouseClickEvent(x, y, MouseButtonType.Left, true, 1, CefEventFlags.None);
		Thread.Sleep(15);
	}
	
	public void HitEnter(int x, int y)
	{
		KeyEvent k = new KeyEvent
		{
			WindowsKeyCode = 0x0D, // Enter
			FocusOnEditableField = true,
			IsSystemKey = false,
			Type = KeyEventType.KeyDown
		};
		_browser.GetBrowser().GetHost().SendKeyEvent(k);
		Thread.Sleep(100);
		k = new KeyEvent
		{
			WindowsKeyCode = 0x0D, // Enter
			FocusOnEditableField = true,
			IsSystemKey = false,
			Type = KeyEventType.KeyUp
		};
		_browser.GetBrowser().GetHost().SendKeyEvent(k);
		Thread.Sleep(100);
	}
