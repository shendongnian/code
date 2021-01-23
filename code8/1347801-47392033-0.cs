    private MemoryStream GenerateExcelStream(List<T> reportData)
        {
            var lines = new List<string>();
            var header = "";
            var attFilter = new NoDisplayInReportAttribute();
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            foreach (PropertyDescriptor prop in properties)
                if (!prop.Attributes.Matches(attFilter))
                    header += prop.Name + ",";
            header = header.Substring(0, header.Length - 1);
            lines.Add(header);
            var valueLines =reportData.Select(row => string.Join(",", header.Split(',').Select(a => row.GetType().GetProperty(a).GetValue(row, null))));
            lines.AddRange(valueLines);
            MemoryStream memoryStream = new MemoryStream();
            TextWriter tw = new StreamWriter(memoryStream);
            lines.ForEach(x => tw.WriteLine(x));
            tw.Flush();
            return memoryStream;
        }
