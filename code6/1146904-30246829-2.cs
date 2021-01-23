    static void Main()
        { 
             Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var parentWindow = new ParentWindow();
            parentWindow.Show();
            Application.Run();  // Not application run without specific form
        }
