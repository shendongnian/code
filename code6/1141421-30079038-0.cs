    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace ConsoleApp
    {
        class Program
        {
            private static IEnumerable<string> Parse(string input)
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    // empty string => nothing to do
                    yield break;
                }
    
                int count = input.Length;
                StringBuilder sb = new StringBuilder();
                int j;
    
                for (int i = 0; i < count; i++)
                {
                    char c = input[i];
                    if (c == ',')
                    {
                        yield return sb.ToString();
                        sb.Clear();
                    }
                    else if (c == '"')
                    {
                        // begin quoted string
                        sb.Clear();
                        for (j = i + 1; j < count; j++)
                        {
                            if (input[j] == '"')
                            {
                                // quote
                                if (j < count - 1 && input[j + 1] == '"')
                                {
                                    // double quote
                                    sb.Append('"');
                                    j++;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                sb.Append(input[j]);
                            }
                        }
                        yield return sb.ToString();
    
                        // clear buffer and skip to next comma
                        sb.Clear();
                        for (i = j + 1; i < count && input[i] != ','; i++) ;
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
            }
    
            [STAThread]
            static void Main(string[] args)
            {
                foreach (string str in Parse("first,\"second, second\",\"\"\"third\"\" third\",\"\"\"fourth\"\", fourth\""))
                {
                    Console.WriteLine(str);
                }
    
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
