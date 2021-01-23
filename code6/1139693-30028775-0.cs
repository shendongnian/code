    var splitted = "Is it allowed to enter this room without asking?".Split(' ');
    StringBuilder str = new StringBuilder();
    int i = 1;
    foreach (var word in splitted)
    {
         str.Append(word);
         if (i % 3 == 0)
         {
             str.Append(System.Environment.NewLine);
         }
         else
         {
              str.Append(" ");
         }
         i++;
     }
     var result = str.ToString();
