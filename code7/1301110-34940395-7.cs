            var paragraphs = Regex.Split(fileText, @"(\r\n?|\n){2}")
                                  .Where(p => p.Any(char.IsLetterOrDigit));
            foreach (var paragraph in paragraphs)
            {
                var words = paragraph.Split(new[] {' '}, 
                                      StringSplitOptions.RemoveEmptyEntries)
                                     .Select(w => w.Trim());
                //do something
            }
