            var lines = new[] 
            {
                new [] { "0075", "0062", "abc", DateTime.Today.ToShortDateString() },
                new [] { "I said \"this is a quote\"" },
                new [] { "Embedded new line: \r\nSecond Line",  string.Concat(Enumerable.Repeat(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator, 5).ToArray()) },
            };
            var path = Path.Combine(Path.GetTempPath(), "TestQuestion34034950.csv");
            using (var writer = new StreamWriter(path))
            {
                CsvWriter.WriteToCsv(lines, writer);
            }
            Console.WriteLine("Wrote " + path);
