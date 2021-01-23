    MemoryStream m = new MemoryStream();
    File.OpenRead("c:\file1.txt").CopyTo(m);
    m.WriteByte(0x0A);                // this is the ASCII code for \n line feed
                                      // You might want or need \n\r in which case you'd 
                                      // need to write 0x0D as well.
    File.OpenRead("c:\file2.txt").CopyTo(m);
    m.WriteByte(0x0A);
    File.OpenRead("c:\file3.txt").CopyTo(m);
    m.Position = 0;
    Console.WriteLine(new StreamReader(m).ReadToEnd());
