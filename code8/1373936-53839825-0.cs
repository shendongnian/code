            var base64_text = new StringBuilder();
            using (var reader = new StreamReader(mhtFile))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    if (line != "Content-Transfer-Encoding: base64") continue;
                    reader.ReadLine(); //chew up the blank line
                    while ((line = reader.ReadLine()) != String.Empty)
                        if (line != null)
                            base64_text.Append(line);
                    break;
                }
                return Encoding.UTF8.GetString(Convert.FromBase64String(base64_text.ToString()));
            }
