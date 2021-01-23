    var defaultOut = Console.Out;
    
    var outfilename = Path.Combine(Environment.CurrentDirectory, "name.txt");
    var outname = new StreamWriter(outfilename);
    Console.SetOut(outname);
    
    Console.WriteLine("aiiii");
    outname.Close();
    Console.SetOut(defaultOut);
                
    Console.Write("hai");
    string nam1 = Console.ReadLine();
    Console.WriteLine(nam1);
    Console.ReadLine();
