     [STAThread]
     static void Main()
     {
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);
          
          // Open the file to read form name. 
          string readText = File.ReadAllText(@"c:\form.txt");
          if(readText == "form1")
          {
             Application.Run(new Form1());
          }
          else if(readText == "form2")
          {
             Application.Run(new Form2());
          }
     }
