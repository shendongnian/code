    public static class CsvWriter
    {
        public static void WriteToCsv(IEnumerable<string> cells, TextWriter writer, CultureInfo cultureInfo = null)
        {
            if (cells == null || writer == null)
                throw new ArgumentNullException();
            string listSeparator = (cultureInfo ?? System.Globalization.CultureInfo.CurrentCulture).TextInfo.ListSeparator;
            bool first = true;
            foreach (var cell in cells)
            {
                if (!first)
                    writer.Write(listSeparator);
                writer.Write(ToCsvCell(cell));
                first = false;
            }
            writer.Write("\r\n");
        }
        public static void WriteToCsv<TEnumerable>(IEnumerable<TEnumerable> lines, TextWriter writer, CultureInfo cultureInfo = null) where TEnumerable : IEnumerable<string>
        {
            if (lines == null || writer == null)
                throw new ArgumentNullException();
            cultureInfo = cultureInfo ?? System.Globalization.CultureInfo.CurrentCulture;
            foreach (var cells in lines)
                WriteToCsv(cells, writer, cultureInfo);
        }
        public static string ToCsv<TEnumerable>(IEnumerable<TEnumerable> lines, CultureInfo cultureInfo = null) where TEnumerable : IEnumerable<string>
        {
            using (var writer = new StringWriter())
            {
                WriteToCsv(lines, writer, cultureInfo);
                return writer.ToString();
            }
        }
        static string ToCsvCell(string s)
        {
            if (s == null)
                return "";
            s = s.Replace("\"", "\"\"\"\"");
            return string.Format("\"=\"\"{0}\"\"\"", s);
        }
    }
