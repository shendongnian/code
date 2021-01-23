    csharp> LoadAssembly("System.Windows.Forms")
    csharp> using System.Windows.Forms
    csharp> LoadAssembly("System.Drawing")
    csharp> using System.Drawing
    csharp> class MyApp : System.Windows.Forms.Form
        {
            public MyApp()
            {
                Label label;
    
                ClientSize = new System.Drawing.Size(250, 250);
    
                label = new Label();
                label.Text = "A Mono CSharp REPL Window";
                label.Dock = DockStyle.Fill;
                label.TextAlign = ContentAlignment.MiddleCenter;
                this.Controls.Add(label);
                Text = "Hello, StackOverFlow";
            }
    
            public static void Main()
            {
                Application.Run(new MyApp());
            }
        }
    MyApp.Main()
