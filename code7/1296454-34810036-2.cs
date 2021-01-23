	static void ShowFile(string fileToShow) {
		using (Process proc = new Process()) {
			ProcessStartInfo psi = new ProcessStartInfo(fileToShow);
			psi.UseShellExecute = true;
			proc.StartInfo = psi;
			proc.Start();
			proc.WaitForExit();
		}
	}
