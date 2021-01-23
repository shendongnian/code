	using System;
	using System.Drawing;
	using System.Reflection;
	using System.Runtime.InteropServices;
	using System.Diagnostics;
	//Import the function
	[DllImport("shell32.dll", EntryPoint="ExtractAssociatedIcon")]
	public static extern IntPtr ExtractAssociatedIcon(IntPtr hInst, string lpIconPath, out ushort lpiIcon);
	//Now get the icon
	ushort uicon;
	IntPtr handle = ExtractAssociatedIcon(this.Handle, Assembly.GetExecutingAssembly().Location, out uicon);
	Icon ico = Icon.FromHandle(handle);
