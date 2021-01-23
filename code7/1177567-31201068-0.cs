    var myScreen = Screen.FromControl(originalForm);
    var otherScreen = Screen.AllScreens.FirstOrDefault(s => !s.Equals(myScreen)) 
               ?? myScreen;
    otherForm.Left = otherScreen.WorkingArea.Left + 120;
    otherForm.Top = otherScreen.WorkingArea.Top + 120;
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Form1 f = new Form1();
        f.StartPosition = FormStartPosition.Manual;
        f.Location = Screen.PrimaryScreen.Bounds.Location;
        Application.Run(f);
    }
