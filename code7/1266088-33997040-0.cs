	public partial class Form1 : Form 
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);
        Process process;
		public Form1() 
        {
            process = Process.GetProcesses()
                .Where(x => x.ProcessName == "MyProcessName")
                .FirstOrDefault();
            //init global keypress as needed
		}
		void gkh_KeyUp(object sender, KeyEventArgs e)
        {
            IntPtr handle = GetForegroundWindow();
            uint processID = GetWindowThreadProcessId(handle, IntPtr.Zero);
            if (p2.Threads.OfType<ProcessThread>().Any(x => x.Id == Convert.ToInt32(processID)))
            {
                //keypress in MyProcessName
            }
			e.Handled = true;
		}
