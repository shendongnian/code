         static void Main(string[] args)
            {
                int begin = -1, end = -1;
    
                string input = "my name is granar";
    
                bool isfirst = true;
                for (int i = 0; i < input.Length; i++)
                {
                    if(input[i] == 'x')
                    {
                        if (isfirst)
                        {
                            begin = i;
                            end = i;
                            isfirst = false;
                        }
                        else
                            end = i;
                    }
                }
    
                if (begin != -1)
                {
                    string substr = input.Substring(begin, end - begin + 1);
    
                    Console.WriteLine(substr);
                }
                else Console.WriteLine("Not Found");
                Console.ReadKey();
            }
