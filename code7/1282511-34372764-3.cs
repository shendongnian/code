        private bool ReadGamesList(string path)
        {
            if (File.Exists(path))
            {                
                XmlSerializer xml=new XmlSerializer(typeof(Game[]));
                var fs=File.Open(path, FileMode.OpenOrCreate, FileAccess.Read);
                games=new List<Game>((Game[])xml.Deserialize(fs));
                fs.Close();
                return true;
            }
            return false;
        }
        private bool SaveGamesList(string path)
        {
            if (games.Count==0) return false;
            XmlSerializer xml=new XmlSerializer(typeof(Game[]));
            var fs=File.Open(path, FileMode.Create, FileAccess.Write);
            xml.Serialize(fs, games.ToArray());
            fs.Close();
            return true;
        }
