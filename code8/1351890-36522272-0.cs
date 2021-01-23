    class Program
    {
        static void Main(string[] args)
        {
            // Unit test the EvaluateBinaryExpression method.
            Console.Out.WriteLine(EvaluateBinaryExpression("true")); // true
            Console.Out.WriteLine(EvaluateBinaryExpression("false")); // false
            Console.Out.WriteLine(EvaluateBinaryExpression("true or false")); // true
            Console.Out.WriteLine(EvaluateBinaryExpression("false or false")); // false
            Console.Out.WriteLine(EvaluateBinaryExpression("true and false")); // false
            Console.Out.WriteLine(EvaluateBinaryExpression("true and true")); // true
            Console.Out.WriteLine(EvaluateBinaryExpression("true and not false")); // false
            //
            // This should give me Ahmed && love && ! Ali which will be true for doc1.
            // TODO: get these values out of the table.
            var doc1Results = new Dictionary<string, bool>()
            {
                { "Ahmed", true },
                { "love", true },
                { "ali", false }
            };
            // Then just call it like this
            Console.Out.WriteLine(EvaluateResults("Ahmed and love and not ali", doc1Results)); // true
        }
        public static bool EvaluateResults(string expression, IDictionary<string, bool> results)
        {
            // TODO validate input expression and results
            // Make sure the expression is padded with whitespace for replacing.
            var replaced = " " + expression + " ";
            foreach (var kvp in results)
            {
                var search = " " + kvp.Key + " ";
                var replacement = " " + kvp.Value.ToString() + " ";
                // TODO make sure casing, etc. doesn't matter.
                replaced = replaced.Replace(search, replacement);
            }
            return EvaluateBinaryExpression(replaced);
        }
        public static bool EvaluateBinaryExpression(string expression)
        {
            // TODO what if this throws an error?
            var dt = new System.Data.DataTable();
            dt.Columns.Add("Test", typeof(object));
            dt.Rows.Add(new object[] { null });
            dt.Columns[0].Expression = expression;
            var value = dt.Rows[0][0] as bool?;
            return value.Value;
        }
    }
