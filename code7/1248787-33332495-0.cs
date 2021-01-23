        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Please select a File to Blah blah bleh...";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string fileName = ofd.FileName;
                    // ... now do something with "fileName"? ...        
                    Application.Run(new Form1(fileName));
                }
            }
        }
