        static string Foo(string input)
        {
            string result = input.Replace("A", "_");
            result = result.Replace("B", "-");
            result = result.Replace("C", "+");
            return result;
        }
