    StringBuilder ab = new StringBuilder("ab(cd)");
    ab.Remove(2, 1);
    ab.Insert(2, "`");
    ab.Remove(5, 1);
    ab.Insert(5, "`");
    ab.Replace("`", "");
    System.Console.Write(ab);
