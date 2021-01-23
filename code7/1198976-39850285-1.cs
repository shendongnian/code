     List<string> _a=new List<string>();
                _a.Add("222-627-90570-0365-042-0031");
                _a.Add("309-95-90570-0243-023-0030");
                List<List<string>> _o = GetSplitedValues(_a);
                foreach (var list in _o)
                {
                    foreach (var str in list)
                    {
                        Console.Write(str);
                    }
                    Console.WriteLine();
                }
