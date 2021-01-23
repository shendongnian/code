            var paragraphMarker = Environment.NewLine + Environment.NewLine;
            var paragraphs = fileText.Split(new[] {paragraphMarker},
                                            StringSplitOptions.RemoveEmptyEntries);
            foreach (var paragraph in paragraphs)
            {
                var words = paragraph.Split(new[] {' '}, 
                                      StringSplitOptions.RemoveEmptyEntries)
                                     .Select(w => w.Trim());
                //do something
            }
