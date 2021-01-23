    class Program
        {
            static void Main(string[] args)
            {
                Program p = new Program();
                p.Run();
            }
            public void Run()
            {
                this.Attempt("");
                this.Attempt("(");
                this.Attempt(")");
                this.Attempt("()");
                this.Attempt("( ");
                this.Attempt(" )");
                this.Attempt("( )");
                this.Attempt(" ( ");
                this.Attempt(" ( ( ");
            }
            private void Attempt(string original)
            {
                System.Console.WriteLine("'" + original + "' => '" + this.Replace(original) + "'" );
            }
            private string Replace(string original)
            {
                string regex = @"(\s*(\)|\()\s*)";
                Regex replacer = new Regex(regex);
                string replaced = replacer.Replace(original, " $2 ");
                return replaced;
            }
