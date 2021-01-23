     public static BackgroundManager Load(string filename)
        {
            XmlSerializer Serializer = new XmlSerializer(typeof(BackgroundManager));
            LoopAgain:
            try
            {
                using (StreamReader Reader = new StreamReader(filename))
                {
                    return Serializer.Deserialize(Reader) as BackgroundManager;
                }
            }
            catch (FileNotFoundException)
            {
                XmlSerializer BaseSerializer = new XmlSerializer(typeof(BackgroundManagerSettings));
                using (StreamWriter Writer = new StreamWriter(filename))
                {
                    BaseSerializer.Serialize(Writer, new BackgroundManager().ToBase());
                    Writer.Close();
                }
                goto LoopAgain;
            }
            catch (InvalidOperationException)
            {
                File.Delete(filename);
                goto LoopAgain;
            }
        }
        public void Save(string filename)
        {
            XmlSerializer Serializer = new XmlSerializer(typeof(BackgroundManagerSettings));
            using (StreamWriter Writer = new StreamWriter(filename))
            {
                Serializer.Serialize(Writer, this.ToBase());
                Writer.Close();
            }
        }
        private dynamic ToBase()
        {
            var Temp = Activator.CreateInstance(typeof(BackgroundManagerSettings));
            FieldInfo[] Fields = Temp.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            foreach (FieldInfo x in Fields)
            {
                x.SetValue(Temp, x.GetValue(this));
            }
            return Temp;
        }
