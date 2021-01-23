        public override void FinishedLaunching(UIApplication application)
        {
            System.Linq.Expressions.Expression<Func<int, bool>> expr = i => i < 5;
            // Compile the expression tree into executable code.
            Func<int, bool> deleg = expr.Compile();
            // Invoke the method and print the output.
            Console.WriteLine("deleg(4) = {0}", deleg(4));
        }
