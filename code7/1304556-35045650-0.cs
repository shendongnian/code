        static void Main(string[] args)
        {
            //with args(user open file with the program)
            if (args != null && args.Length > 0)
            {
                string fileName = args[0];
                //Check file exists
                if(File.Exists(fileName))
                {
                    //start your application with the path argument and use it to open the file onload
                }
                
            }
                //without args
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
