        static void WriteCsvFile(string filename, IEnumerable<Person> people)
        {
            StreamWriter textWriter = File.CreateText(filename);
            var csvWriter = new CsvWriter(textWriter, System.Globalization.CultureInfo.CurrentCulture);
            csvWriter.WriteRecords(people);
            textWriter.Close();
        }
