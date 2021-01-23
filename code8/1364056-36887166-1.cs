	public void RefreshWindow()
	{
		Guid CLSID_ShellApplication = new Guid("13709620-C279-11CE-A49E-444553540000");
		Type shellApplicationType = Type.GetTypeFromCLSID(CLSID_ShellApplication, true);
		object shellApplication = Activator.CreateInstance(shellApplicationType);
		object windows = shellApplicationType.InvokeMember("Windows", System.Reflection.BindingFlags.InvokeMethod, null, shellApplication, new object[] { });
		Type windowsType = windows.GetType();
		object count = windowsType.InvokeMember("Count", System.Reflection.BindingFlags.GetProperty, null, windows, null);
		Parallel.For(0, (int)count, i =>
		{
			object item = windowsType.InvokeMember("Item", System.Reflection.BindingFlags.InvokeMethod, null, windows, new object[] { i });
			Type itemType = item.GetType();
			// Only refresh windows explorers
			string itemName = (string)itemType.InvokeMember("Name", System.Reflection.BindingFlags.GetProperty, null, item, null);
			if (itemName == "Windows Explorer" || itemName == "File Explorer")
			{
				string currDirectory = (string)itemType.InvokeMember("LocationURL", System.Reflection.BindingFlags.GetProperty, null, item, null);
				Console.WriteLine(currDirectory);
			}
		});
	}
