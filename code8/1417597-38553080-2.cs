    string name1 = Console.ReadLine();
    var temp = name1.Split(' ');
    string sub = string.Join(" ", temp.TakeWhile(c => c != temp.Last()));
    string mark = temp.Last();
    total += Convert.ToInt32(mark);
    Console.Write(sub + " " + mark + "  ");
