    StringBuilder sb1 = new StringBuilder(), sb2 = new StringBuilder();
    sb1.Append("something").Append('1', 100).Replace("1", "");
    sb2.Append("something");
    Console.WriteLine(sb1.Equals(sb2)); // False
    Console.WriteLine(sb1.ToString().Equals(sb2.ToString())); // True
