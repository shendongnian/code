    #include <winuser.h>
    BEGIN_INTEROP_NAMESPACE
	using namespace System;
	using namespace System::Collections::Generic;
	using namespace HFSLIB::Barcode;
	using namespace HFSLIB::Barcode::Interop;
	using namespace HFSLIB::Barcode::Infrastructure::BarcodeScannerListener;
	/// <summary>
	/// Provides some helper methods that help the BarcodeScannerListener use native
	/// Windows APIs without resorting to P/Invoking from C#.
	/// </summary>
	public ref class BarcodeScannerListenerInteropHelper
	{
		public:
			/// <summary>
			/// Returns a dictionary of barcode device handles to information about
			/// the device.
			/// </summary>
			/// <param name="hardwareIds">The enumerable of hardware IDs to filter by.</param>
			/// <returns>The device handle-to-information mapping of the filtered hardware IDs.</returns>
			Dictionary<IntPtr, BarcodeScannerDeviceInfo^>^ InitializeBarcodeScannerDeviceHandles(
				IEnumerable<String^>^ hardwareIds);
			/// <summary>
			/// Registers ourselves to listen to raw input from keyboard-like devices.
			/// </summary>
			/// <param name="hwnd">the handle of the form that will receive the raw
			/// input messages</param>
			/// <exception cref="InvalidOperationException">if the call to register with the
			/// raw input API fails for some reason</exception>
			void HookRawInput(IntPtr hwnd);
			/// <summary>
			/// Gets information from a WM_INPUT message.
			/// </summary>
			/// <param name="rawInputHeader">The LParam from the WM_INPUT message.</param>
			/// <param name="deviceHandle">[Out] The device handle that the message came from.</param>
			/// <param name="handled">[Out] True if the message represents a keystroke from that device.</param>
			/// <param name="buffer">[Out] If handled is true, this contains the characters that the keystroke represents.</param>
			void GetRawInputInfo(
				IntPtr rawInputHeader, 
				IntPtr% deviceHandle, 
				bool% handled,
				String^% buffer);
		private:
			/// <summary>
			/// Converts a native raw input type into our version.
			/// </summary>
			/// <param name="rawInputType">The raw input type.</param>
			/// <returns>Our version of the type.</returns>
			static BarcodeScannerDeviceType GetBarcodeScannerDeviceType(DWORD rawInputType);
	};
    END_INTEROP_NAMESPACE
