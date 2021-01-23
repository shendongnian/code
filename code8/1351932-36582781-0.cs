    for (int i = 0; i < rowLength; i++)
    {
       for (int j = 0; j < colLength; j++)
       {
          Console.Write(string.Format("{0,6} |", arr[j, i]));
       }
       Console.Write(Environment.NewLine);
    }
