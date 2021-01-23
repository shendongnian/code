    public static class Extensions
    {
        public static string[] DocMetaInfoFields =
        {
            MetaInfoFields.Title, MetaInfoFields.Author,
            MetaInfoFields.DocumentType, MetaInfoFields.ModifiedBy
        };
        public static string GetDocumentType(this object metaInfo)
        {
            var match = GetRegexMatch(metaInfo as string, MetaInfoFields.DocumentType);
            return (match.Groups.Count > 1)
                ? match.Groups[1].Value
                : string.Empty;
        }
        public static Dictionary<string, string> GetDocMetaProperties(this object metaInfo)
        {
            var properties = new Dictionary<string, string>();
            foreach (var field in DocMetaInfoFields)
            {
                var match = GetRegexMatch(metaInfo as string, field);
                properties.Add(field,
                    (match.Groups.Count > 1)
                        ? match.Groups[1].Value
                        : string.Empty);
            }
            return properties;
        }
        public static StringBuilder FormatCamlValues(this StringBuilder sb, string valueTag, string listName,
            IEnumerable<string> clientReferences)
        {
            foreach (var clientRef in clientReferences)
            {
                sb.AppendFormat(valueTag, listName, clientRef);
            }
            return sb;
        }
        public static List<ClientDocumentListItem> ToClientDocumentList(this ListItemCollection files)
        {
            return files.ToList().ConvertAll(ListItemToClientDocItem);
        }
        private static Match GetRegexMatch(string searchString, string fieldName)
        {
            string regexCapture = string.Format(@"^{0}:\w{{2}}\|([^.(\r|\n)]*)[\r\n|\n\r]+\w", fieldName);
            return Regex.Match(searchString, regexCapture, RegexOptions.Multiline);
        }
    }
    /// <summary>
    /// Defines the field names inside the MetaInfo composite field returned while using the SharePoint client object CamlQuery() method
    /// </summary>
    public static class MetaInfoFields
    {
        public static string MetaInfoFieldName = "MetaInfo";
        public static string Title = "vti_title";
        public static string Author = "vti_author";
        public static string DocumentType = "Document Type";
        public static string ModifiedBy = "vti_modifiedby";
    }
