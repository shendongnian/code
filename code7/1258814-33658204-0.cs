         foreach (string line in lines)
         {
            if (String.IsNullOrWhiteSpace(line)) 
            {
                lines.Delete(line);
                Continue;
            }
            if (line.Length >= longestLine) // ">=" instead of "==" just to be on the safe side
            {
               lines.Delete(line);
            }
        }
