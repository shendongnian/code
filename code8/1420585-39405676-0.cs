	private static void DisableWPFTabletSupport()
	{
		// Get a collection of the tablet devices for this window.  
		var devices = Tablet.TabletDevices;
		if (devices.Count > 0)
		{
			// Get the Type of InputManager.
			var inputManagerType = typeof(InputManager);
			// Call the StylusLogic method on the InputManager.Current instance.
			var stylusLogic = inputManagerType.InvokeMember("StylusLogic",
						BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
						null, InputManager.Current, null);
			if (stylusLogic != null)
			{
				//  Get the type of the stylusLogic returned from the call to StylusLogic.
				var stylusLogicType = stylusLogic.GetType();
				// Loop until there are no more devices to remove.
				while (devices.Count > 0)
				{
					// Remove the first tablet device in the devices collection.
					stylusLogicType.InvokeMember("OnTabletRemoved",
							BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.NonPublic,
							null, stylusLogic, new object[] { (uint)0 });
				}
			}
		}
        // END OF ORIGINAL CODE
		// hook into internal class SystemResources to keep it from updating the TabletDevices on system events
		object hwndWrapper = GetSystemResourcesHwnd();
		if (hwndWrapper != null)
		{
			// invoke hwndWrapper.AddHook( .. our method ..)
			var internalHwndWrapperType = hwndWrapper.GetType();
			// if the delegate is already set, we have already added the hook.
			if (_handleAndHideMessageDelegate == null)
			{
				// create the internal delegate that will hook into the window messages
				// need to hold a reference to that one, because internally the delegate is stored through a WeakReference object
				var internalHwndWrapperHookDelegate = internalHwndWrapperType.Assembly.GetType("MS.Win32.HwndWrapperHook");
				var handleAndHideMessagesHandle = typeof(Win32PointerDeviceDriver).GetMethod(nameof(HandleAndHideMessages), BindingFlags.Static | BindingFlags.NonPublic);
				_handleAndHideMessageDelegate = Delegate.CreateDelegate(internalHwndWrapperHookDelegate, handleAndHideMessagesHandle);
				// add a delegate that handles WM_TABLET_ADD
				internalHwndWrapperType.InvokeMember("AddHook",
					BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.Public,
					null, hwndWrapper, new object[] { _handleAndHideMessageDelegate });
			}
		}
	}
	private static Delegate _handleAndHideMessageDelegate = null;
	private static object GetSystemResourcesHwnd()
	{
		var internalSystemResourcesType = typeof(Application).Assembly.GetType("System.Windows.SystemResources");
		// get HwndWrapper from internal property SystemRessources.Hwnd;
		var hwndWrapper = internalSystemResourcesType.InvokeMember("Hwnd",
					BindingFlags.GetProperty | BindingFlags.Static | BindingFlags.NonPublic,
					null, null, null);
		return hwndWrapper;
	}
