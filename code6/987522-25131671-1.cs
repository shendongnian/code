    System.IO.File.WriteAllLines(newPath, System.IO.File.ReadLines(oldPath).Select(c =>
                       {
                           int semicolon = c.IndexOf(';');
                           if (semicolon > -1)
                               return c.Remove(semicolon);
                           else
                               return c;
                       }));
