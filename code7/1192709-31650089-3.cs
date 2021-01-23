    [STAThread]
            static void Main(string[] args)
            {
                //check whether you get this by double-clicking file or debug with compiler
                if (args != null && args.Length > 0)
                {
                    //if args is not NULL, it means you do it by double-clicking files
                   //so, you can get the filename by getting the args
                    string fileName = args[0];
                    //Check file exists
                    if (File.Exists(fileName))
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
     
                        Form1 MainForm = new Form1();
                        //this would call method open (like with open dialogue)
                        //you can get path or filename from args in Main Form
                        //MainForm is your notepad form
                        MainForm.readOnOpen(fileName);
    
    
                        Application.Run(MainForm);
                    }    
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Form1());
                }
