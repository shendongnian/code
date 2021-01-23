    string s1;
    s1 = Console.ReadLine();
    
    byte[] bytes = Encoding.ASCII.GetBytes(s1);
    int result = BitConverter.ToInt32(bytes, 0);
    Console.WriteLine(result);
    
    String decoded = Encoding.ASCII.GetString(bytes);
    Console.WriteLine("Decoded string: '{0}'", decoded);
