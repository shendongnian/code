    List<Tuple<string, string>> conflicts = new List<Tuple<string, string>>();
    List<Tuple<string, string>> noConflicts = new List<Tuple<string, string>>();
    conflicts.Add(new Tuple<string, string>("Maths", "English"));
    conflicts.Add(new Tuple<string, string>("Science", "French"));
    conflicts.Add(new Tuple<string, string>("French", "Science"));
    conflicts.Add(new Tuple<string, string>("English", "Maths"));
    foreach(Tuple<string,string> t in conflicts)
    {
          if(!noConflicts.Contains(t) && !noConflicts.Contains(new Tuple<string,string>(t.Item2,t.Item1)))
               noConflicts.Add(t);
    }
    foreach(Tuple<string, string> t in noConflicts)
           Console.WriteLine(t.Item1 + "," + t.Item2);
