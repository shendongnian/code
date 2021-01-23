      public string formatText(string textData)
      { 
                textData = new Regex(@" {2,}").Replace(textData.Trim(), @" ");
                var left = Console.CursorLeft; var top = Console.CursorTop; var lines = new List<string>();
                for (var i = 0; textData.Length > 0; i++)
                {
                    lines.Add(textData.Substring(0, Math.Min(Console.WindowWidth, textData.Length)));
                    var length = lines[i].LastIndexOf(" ", StringComparison.Ordinal);
                    if (length > 0) lines[i] = lines[i].Remove(length);
                    textData = textData.Substring(Math.Min(lines[i].Length + 1, textData.Length));
                    Console.SetCursorPosition(left, top + i); Console.WriteLine(lines[i]);
                }
      }
