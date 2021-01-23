            string input = "this is just a simple text string";
            char[] chars = { 't', 's' };
            var array = input.Split();
            List<string> result = new List<string>();
            foreach(var word in array)
            {
                bool isValid = true;
                foreach (var c in chars)
                {
                    if (!word.Contains(c))
                    {
                        isValid = false;
                        break;
                    }
                }
                if(isValid) result.Add(word);
            }
