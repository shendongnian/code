     using (var fileStream = new FileStream(Path, FileMode.Open, FileAccess.Read))
            {
                using (var streamReader = new StreamReader(fileStream))
                {
                    var line = streamReader.ReadLine();
                    var res = GetCharacterRepetitionAndPosition(line);
                    // do whatever you want with this output
                    Console.WriteLine(res);
                }
            }
