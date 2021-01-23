		using System;
		using System.Collections.Generic;
		using System.Linq;
		using System.Runtime.InteropServices;
		using System.Text;
		using System.Threading.Tasks;
		using System.Windows.Controls;
		using System.Windows.Threading;
		namespace WPF_DT_Soft_Keyboard
		{
		    class TouchTextbox : TextBox 
		    {
			/// <summary>
			/// Private Container
			/// </summary>
			DispatcherTimer mBringIntoViewTimer = new DispatcherTimer();
			/// <summary>
			///  DLL imports
			/// </summary>
			[DllImport("user32.dll")]
			public static extern int FindWindow(string lpClassName, string lpWindowName);
			[DllImport("user32.dll")]
			public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);
			[DllImport("user32.dll")]
			public static extern int MoveWindow(int hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
			[DllImport("user32.dll")]
			public static extern int SetWindowPos(int hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
			[DllImport("Kernel32.dll")]
			public static extern uint GetLastError();
			/// <summary>
			/// Constante
			/// </summary>
			public const int WM_SYSCOMMAND = 0x0112;
			public const int SC_CLOSE = 0xF060;
			public const int HWND_TOP = 0;
			public const int SWP_NOSIZE = 0x0001;
			public const int SWP_NOZORDER = 0x0004;
			public const int SWP_SHOWWINDOW = 0x0040;
			public const int BRING_INTO_VIEW_DELAY = 500;
			/// <summary>
			/// TouchTextbox
			/// </summary>
			public TouchTextbox()
			{
			    mBringIntoViewTimer.IsEnabled = false;
			    mBringIntoViewTimer.Tick += MyTimer_Tick;
			    mBringIntoViewTimer.Interval = new TimeSpan(0, 0, 0, 0, BRING_INTO_VIEW_DELAY);
			}
			/// <summary>
			/// MyTimer_Tick
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void MyTimer_Tick(object sender, EventArgs e)
			{
			    mBringIntoViewTimer.IsEnabled = false;
			    this.BringIntoView();
			}
			/// <summary>
			/// OnGotFocus
			/// </summary>
			/// <param name="e"></param>
			protected override void OnGotFocus(System.Windows.RoutedEventArgs e)
			{
			    base.OnGotFocus(e);
			    ShowSoftKeyboard();
			    mBringIntoViewTimer.IsEnabled = true;
			}
			///// <summary>
			///// OnLostFocus
			///// </summary>
			///// <param name="e"></param>
			//protected override void OnLostFocus(System.Windows.RoutedEventArgs e)
			//{
			//    base.OnLostFocus(e);
			//    HideSoftKeyboard();
			//}
			/// <summary>
			/// OnPreviewKeyUp
			/// </summary>
			/// <param name="e"></param>
			protected override void OnPreviewKeyUp(System.Windows.Input.KeyEventArgs e)
			{
			    base.OnPreviewKeyUp(e);
			    if (e.Key == System.Windows.Input.Key.Enter) HideSoftKeyboard();
			}
			/// <summary>
			/// ShowSoftKeyboard
			/// </summary>
			private void ShowSoftKeyboard()
			{
			    Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\TabletTip\1.7", true).SetValue("EdgeTargetDockedState", "1", Microsoft.Win32.RegistryValueKind.DWord);
			    System.Diagnostics.Process.Start(@"C:\Program Files\Common Files\Microsoft Shared\ink\TabTip.exe");
			}
			/// <summary>
			/// HideSoftKeyboard
			/// </summary>
			private void HideSoftKeyboard()
			{
			    int iHandle = FindWindow("IPTIP_Main_Window", "");
			    if (iHandle > 0)
			    {
				SendMessage(iHandle, WM_SYSCOMMAND, SC_CLOSE, 0);
			    }
			}
		    }
		}
