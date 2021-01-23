    string plaintext = "hello world";
    byte[] b = ASCIIEncoding.ASCII.GetBytes(plaintext);
    Console.WriteLine(b); // new bytes[] { 104, 101, 108, 108, 111, 32, 119, 111, 114, 108, 100 }
    string s = ASCIIEncoding.ASCII.GetString(b);
    Console.WriteLine(s); // "hello world"
