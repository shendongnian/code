    public Class1()
            {
                var myList = new List<string>();
                var foo = myList.All(l=>LessThan16Char(l,16));
            }
    
    
            public bool LessThan16Char(string input, int max)
            {
                return (input.Length < max);
            }
