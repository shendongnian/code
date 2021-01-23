                StringBuilder s = new StringBuilder();
                foreach (var line in txtsample.Inlines)
                {
                    if (line is LineBreak)
                        s.AppendLine();
                    else if (line is Run)
                        s.Append(((Run)line).Text);
                }
                var text = s.ToString();
               }
