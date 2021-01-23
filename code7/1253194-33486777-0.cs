            static void Main(string[] args)
            {
                Console.WriteLine("enter one string:");
                var input = Console.ReadLine();
                Console.WriteLine(RemoveCBC(input));
            }
    
            static string RemoveCBC(string source)
            {
                var result = new StringBuilder();
    
                for (int i = 0; i < source.Length; i++)
                {
                    if (i + 2 == source.Length)
                        break;
    
                    var c = source[i];
                    var b = source[i + 1];
                    var c2 = source[i + 2];
    
                    if (c == 'c' && c2 == 'c' && b == 'b')
                        i = i + 2;
                    else
                        result.Append(source[i]);
                }
    
                return result.ToString();
            }
