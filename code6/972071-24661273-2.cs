    // MyForm.cs
    namespace MyNamespace
    {
        public partial class MyForm : Form
        {
            string Title, Line1, Line2, Line3, Line4;
            public MyForm()
            {
                string[] args = Environment.GetCommandLineArgs();
                if (args.Length == 6)
                {
                    // note that args[0] is the path of the executable
                    Title = args[1];
                    Line1 = args[2];
                    Line2 = args[3];
                    Line3 = args[4];
                    Line4 = args[5];
                }
            }
        }
    }
