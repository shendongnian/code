    using System.Linq;
    . . . . .  .
    List<string> lines = myTb.Lines.ToList();
    int index;
    while (index < lines.Length)
    {
         if (lines[i].IndexOf(" title ", StringComparison.OrdinalIgnoreCase) > -1)
         {
             lines.Insert(index, "my insert text into new line");
             // we just added new line, so current line is index + 1 
             index++; 
         }
        index++;
    }
    myTb.Lines = lines.ToArray();
