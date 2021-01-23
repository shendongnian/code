    public static class Extensions
    {
        public static void Serialize(this IEnumerable<dynamic> enumerable, Stream stream)
        {
            var rows =
                new Rows(
                    enumerable
                        .Cast<IEnumerable<KeyValuePair<string, object>>>()
                        .Select(row =>
                            new Row(row.Select(cell => new Cell(cell)))));
            XmlSerializer serializer = new XmlSerializer(typeof(Rows));
            serializer.Serialize(stream, rows);
        }
    }
