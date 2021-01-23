      public static string CleanupStringForValidXMLExport(this string inputString)
        {
            StringBuilder s = new StringBuilder();
            foreach(char ch in inputString)
            {
                if (XmlConvert.IsXmlChar(ch))
                    s.Append(ch);
            }
            return s;
        }
