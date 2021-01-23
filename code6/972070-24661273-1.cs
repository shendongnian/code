    // MyForm.cs
    namespace MyNamespace
    {
        public partial class MyForm : Form
        {
            string Title, Line1, Line2, Line3, Line4;
            public MyForm(string[] args)
            {
                if (args.Length == 5)
                {
                    Title = args[0];
                    Line1 = args[1];
                    Line2 = args[2];
                    Line3 = args[3];
                    Line4 = args[4];
                }
            }
        }
    }
