    private string xmlPath = System.Web.Hosting.HostingEnvironment.MapPath(WebConfigurationManager.AppSettings["DATA_XML"]);
    private object objLock = new Object();
    public string ErrorMessage { get; set; }
    const string rootName = "MessageHistory";
    static readonly XmlSerializer serializer = new XmlSerializer(typeof(StoredMessage), new XmlRootAttribute(rootName));
    public MessageHistory Operation(string from, string message, FileAccess access)
    {
        var list = new MessageHistory();
        lock (objLock)
        {
            ErrorMessage = null;
            try
            {
                using (var file = File.Open(xmlPath, FileMode.OpenOrCreate))
                {
                    list.AddRange(XmlSerializerHelper.ReadObjects<StoredMessage>(file, false, serializer));
                    if (list.Count == 0 && String.IsNullOrEmpty(message))
                    {
                        from = "Code Window";
                        message = "Created File";
                    }
                    var item = new StoredMessage()
                    {
                        From = from,
                        Date = DateTime.Now.ToString("s"),
                        Message = message
                    };
                    if ((access == FileAccess.ReadWrite) || (access == FileAccess.Write))
                    {
                        file.Seek(0, SeekOrigin.End);
                        var writerSettings = new XmlWriterSettings
                        {
                            OmitXmlDeclaration = true,
                            Indent = true, // Optional; remove if compact XML is desired.
                        };
                        using (var textWriter = new StreamWriter(file))
                        {
                            if (list.Count > 0)
                                textWriter.WriteLine();
                            using (var xmlWriter = XmlWriter.Create(textWriter, writerSettings))
                            {
                                serializer.Serialize(xmlWriter, item);
                            }
                        }
                    }
                    list.Add(item);
                }
            }
            catch (Exception error)
            {
                var sb = new StringBuilder();
                int index = 0;
                sb.AppendLine(String.Format("Top Level Error: <b>{0}</b>", error.Message));
                var err = error.InnerException;
                while (err != null)
                {
                    index++;
                    sb.AppendLine(String.Format("\tInner {0}: {1}", index, err.Message));
                    err = err.InnerException;
                }
                ErrorMessage = sb.ToString();
            }
        }
        return list;
    }
