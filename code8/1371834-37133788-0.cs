    public static class ExtensionMethods
    {
        public static string ToText(this int[][] value)
        {
              StringBuilder sb = new StringBuilder();
              for (int i = 0; i < value.Length; i++)
              {               
                   for (int j = 0; j < value[i].Length; j++)
                       sb.AppendLine(value[i][j]);
              }
              return sb.ToString();
         }
    }
