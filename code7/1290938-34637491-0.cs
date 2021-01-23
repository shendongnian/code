            private Tuple<string, string, string> Parse(string input)
            {
                if (string.IsNullOrEmpty(input))
                    return null;
    
                var arr = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
    
                if (arr.Length == 1)
                {
                    return new Tuple<string, string, string>(null, null, arr[0]);
                }
    
                if (arr.Length == 2)
                {
                    return new Tuple<string, string, string>(arr[0], null, arr[1]);
                }
    
                return new Tuple<string, string, string>(arr[0], String.Join(" ", arr.Skip(1).Take(arr.Length - 2)), arr[arr.Length - 1]);
            }
