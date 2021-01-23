    string[] months = File.ReadAllLines("Month.txt");
    string str = String.Join("\n",months);
    //Or string str = String.Join(Environment.NewLine, months);
    Console.WriteLine(str);
    Console.ReadLine();
