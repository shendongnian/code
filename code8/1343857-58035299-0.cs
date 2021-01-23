        public static string JsonToCsv(string jsonContent, string delimiter)
        {
            var expandos = JsonConvert.DeserializeObject<ExpandoObject[]>(jsonContent);
            using (var writer = new StringWriter())
            {
                using (var csv = new CsvWriter(writer))
                {
                    csv.Configuration.Delimiter = delimiter;
                    csv.WriteRecords(expandos as IEnumerable<dynamic>);
                }
                return writer.ToString();
            }
        }
