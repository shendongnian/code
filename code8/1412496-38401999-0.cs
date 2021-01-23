    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var myForm = new Form();
            myForm.BackColor = System.Drawing.Color.Red;
            // Do anything else to the form here in code
            
            Application.Run(myForm);
        }
