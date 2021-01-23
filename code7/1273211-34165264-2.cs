    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Permissions;
    using System.Text;
    using System.Windows.Forms;
    using HFSLIB.Barcode.Infrastructure.BarcodeScannerListener;
    using HFSLIB.Barcode.Interop;
    namespace HFSLIB.Barcode
    {
	/// <summary>
	/// This class uses Windows's native Raw Input API to listen for input from
	/// a certain set of barcode scanners and devices. This way, the application
	/// can receive input from a barcode scanner without the user having to
	/// worry about whether or not a certain text field has focus, which was a
	/// big problem
	/// </summary>
	public class BarcodeScannerListener : NativeWindow
	{
		/// <summary>
		/// A mapping of device handles to information about the barcode scanner
		/// devices.
		/// </summary>
		private Dictionary<IntPtr, BarcodeScannerDeviceInfo> devices;
		/// <summary>
		/// The WM_KEYDOWN filter.
		/// </summary>
		private BarcodeScannerKeyDownMessageFilter filter;
		/// <summary>
		/// The barcode currently being read.
		/// </summary>
		private StringBuilder keystrokeBuffer;
		/// <summary>
		/// The interop helper.
		/// </summary>
		private BarcodeScannerListenerInteropHelper interopHelper =
			new BarcodeScannerListenerInteropHelper();
		/// <summary>
		/// Event fired when a barcode is scanned.
		/// </summary>
		public event EventHandler BarcodeScanned;
		/// <summary>
		/// Attaches the listener to the given form.
		/// </summary>
		/// <param name="form">The form to attach to.</param>
		public void Attach(Form form)
		{
			IntPtr hwnd;
			if (form == null)
			{
				throw new ArgumentNullException("form");
			}
			hwnd = form.Handle;
			this.keystrokeBuffer = new StringBuilder();
			this.InitializeBarcodeScannerDeviceHandles();
			this.interopHelper.HookRawInput(hwnd);
			this.HookHandleEvents(form);
			this.AssignHandle(hwnd);
			this.filter = new BarcodeScannerKeyDownMessageFilter();
			Application.AddMessageFilter(this.filter);
		}
		/// <summary>
		/// Hook into the form's WndProc message. We listen for WM_INPUT and do
		/// special processing on the raw data.
		/// </summary>
		/// <param name="m">the message</param>
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
				case NativeMethods.WM_INPUT:
					if (this.ProcessRawInputMessage(m.LParam))
					{
						this.filter.FilterNext = true;
					}
					break;
			}
			base.WndProc(ref m);
		}
		/// <summary>
		/// Fires the barcode scanned event.
		/// </summary>
		/// <param name="deviceInfo">information about the device that generated
		/// the barcode</param>
		private void FireBarcodeScanned(BarcodeScannerDeviceInfo deviceInfo)
		{
			string barcode;
			EventHandler handler;
			barcode = this.keystrokeBuffer.ToString();
			if (barcode != null && barcode.Length > 0)
			{
				handler = this.BarcodeScanned;
				this.keystrokeBuffer = new StringBuilder();
				if (handler != null)
				{
					handler(this, new BarcodeScannedEventArgs(barcode, deviceInfo));
				}
			}
		}
		/// <summary>
		/// Hooks into the form's HandleCreated and HandleDestoryed events
		/// to ensure that we start and stop listening at appropriate times.
		/// </summary>
		/// <param name="form">the form to listen to</param>
		private void HookHandleEvents(Form form)
		{
			form.HandleCreated += this.OnHandleCreated;
			form.HandleDestroyed += this.OnHandleDestroyed;
		}
		/// <summary>
		/// Initializes the barcode scanner device handles.
		/// </summary>
		private void InitializeBarcodeScannerDeviceHandles()
		{
			BarcodeScannerListenerConfigurationSection config;
			BarcodeScannerListenerConfigurationElementCollection hardwareIdsConfig;
			IEnumerable<string> hardwareIds;
			config = BarcodeScannerListenerConfigurationSection.GetConfiguration();
			hardwareIdsConfig = config.HardwareIds;
			hardwareIds = from hardwareIdConfig in hardwareIdsConfig.Cast<BarcodeScannerListenerConfigurationElement>()
						  select hardwareIdConfig.Id;
			this.devices = this.interopHelper.InitializeBarcodeScannerDeviceHandles(hardwareIds);
		}
		/// <summary>
		/// When the form's handle is created, let's hook into it so we can see
		/// the WM_INPUT event.
		/// </summary>
		/// <param name="sender">the form whose handle was created</param>
		/// <param name="e">the event arguments</param>
		private void OnHandleCreated(object sender, EventArgs e)
		{
			this.AssignHandle(((Form)sender).Handle);
		}
		/// <summary>
		/// When the form's handle is destroyed, let's unhook from it so we stop
		/// listening and allow the OS to free up its resources.
		/// </summary>
		/// <param name="sender">the form whose handle was destroyed</param>
		/// <param name="e">the event arguments</param>
		private void OnHandleDestroyed(object sender, EventArgs e)
		{
			this.ReleaseHandle();
		}
		/// <summary>
		/// Process the given WM_INPUT message.
		/// </summary>
		/// <param name="rawInputHeader">the rawInputHeader of the message</param>
		/// <returns>whether or not the keystroke was handled</returns>
		private bool ProcessRawInputMessage(IntPtr rawInputHeader)
		{
			BarcodeScannerDeviceInfo deviceInfo;
			bool handled;
			bool keystroke;
			string localBuffer;
			IntPtr rawInputDeviceHandle;
			handled = false;
			keystroke = false;
			localBuffer = string.Empty;
			rawInputDeviceHandle = IntPtr.Zero;
			this.interopHelper.GetRawInputInfo(
				rawInputHeader,
				ref rawInputDeviceHandle,
				ref keystroke,
				ref localBuffer);
			if (this.devices.TryGetValue(rawInputDeviceHandle, out deviceInfo) && keystroke)
			{
				handled = true;
				if (localBuffer.Length == 1 && localBuffer[0] == 0xA)
				{
					this.FireBarcodeScanned(deviceInfo);
				}
				else
				{
					this.keystrokeBuffer.Append(localBuffer);
				}
			}
			return handled;
		}
	}
    }
