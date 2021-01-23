		[DllImport("user32.dll")]
		static extern bool SetForegroundWindow(IntPtr hWnd);
		private static void OpenExcelWithoutRibbon() {
			Application excelApp = new Application();
			excelApp.Visible = true;
			
			Process prc = Process.GetProcessesByName("EXCEL").First();
			prc.WaitForInputIdle();
			IntPtr h = prc.MainWindowHandle;
			SetForegroundWindow(h);
			System.Windows.Forms.SendKeys.SendWait("^{F1}");			
		}
