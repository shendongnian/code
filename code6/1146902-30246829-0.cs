    static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var parentForm = new ParentForm();
            parentForm.Show();
            Application.Run();   // Not application run without specific form
        }
