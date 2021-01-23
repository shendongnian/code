        public static void ParseToModel(string file)
        {
            if (string.IsNullOrEmpty(file))
                throw new ArgumentNullException();
            XmlSerializer serialize = new XmlSerializer(typeof(CanvasResult));
            using(FileStream stream = new FileStream(file, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                using(XmlReader reader= XmlReader.Create(stream))
                {
                    CanvasResult model = serialize.Deserialize(reader) as CanvasResult;
                    ParseToDatabase(model);
                }
        }
