    public static class DeDupCsv
    {
        public static IEnumerable<Series<string, object>> ReadCsv(this string file)
        {
            // NuGet: PM> Install-Package LumenWorksCsvReader
            using (var csv = new CsvReader(new StreamReader(file), true))
            {
                int fieldCount = csv.FieldCount;
                string[] headers = csv.GetFieldHeaders();
                while (csv.ReadNextRecord())
                {
                    var seriesBuilder = new SeriesBuilder<string>();
                    for (int i = 0; i < fieldCount; i++)
                    {
                        seriesBuilder.Add(headers[i], csv[i]);
                    }
                    yield return seriesBuilder.Series;
                }
            }
        }
        public static IEnumerable<TSource> DistinctObject<TSource, TCompare>(this IEnumerable<TSource> source, Func<TSource, TCompare> compare)
        {
            var set = new HashSet<TCompare>();
            return source.Where(element => set.Add(compare(element)));
        }
        public static IEnumerable<Series<string, object>> DeDupify(this IEnumerable<Series<string, object>> source, string key)
        {
            return source.DistinctObject(s => s.Get(key));
        }
    }
