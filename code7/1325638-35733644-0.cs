    var hdr = File.ReadAllText("file.txt")
                  .Split(new[] { "[HRData]" }, StringSplitOptions.None)[1].Trim(new[] { '\n', '\r' })
                  .Split(new[] { Environment.NewLine }, StringSplitOptions.None)
                  .Select(line => line.Split().ToList())
                  .ToList();
