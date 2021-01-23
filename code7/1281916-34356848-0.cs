        public static string ToEdmx(this System.Data.Entity.DbContext context)
        {
            var sb = new StringBuilder();
            using (var textWriter = new StringWriter(sb))
            using (var xmlWriter = System.Xml.XmlWriter.Create(textWriter, new System.Xml.XmlWriterSettings { Indent = true, IndentChars = "    " }))
            {
                System.Data.Entity.Infrastructure.EdmxWriter.WriteEdmx(context, xmlWriter);
                textWriter.Flush();
            }
            return sb.ToString();
        }
