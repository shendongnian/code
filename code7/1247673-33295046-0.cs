    public static List<string> ReadInCSV(string absolutePath) {
        List<string> result = new List<string>();
        string value;
        using (TextReader fileReader = File.OpenText(absolutePath)) {
            var csv = new CsvReader(fileReader);
            csv.Configuration.HasHeaderRecord = false;
            while (csv.Read()) {
               for(int i=0; csv.TryGetField<string>(i, out value); i++) {
                    result.Add(value);
                }
            }
        }
        return result;
    }
