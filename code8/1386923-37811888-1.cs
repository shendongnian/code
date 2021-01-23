    static void Main(string[] args)
            {
                if (args.Length <= 1) return;
                
                try
                {
                    if (args.Length == 2)
                    {
                        _IpAddress = args[0];
                        _IpPort = args[1];
                        FunctionName(_IpAddress, _IpPort);
                    }
                    else
                    {
                        _return
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Invalid number of parameters!");
                }
            }
