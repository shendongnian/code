    var sb = new StringBuilder();
    while (x <= 30) {  
        sb.Append(x).Append(", ");
        x++;
    }
    sb.Length -= 2;  // Remove the 2 last characters ", "
    Console.WriteLine(sb);
