            string[] files = Directory.GetFiles(@"resources", "*.wav");
            Dictionary<string, Stream> dic = new Dictionary<string, Stream>();
            foreach (var file in files)
            {
                byte[] data = File.ReadAllBytes(file);
                MemoryStream stream = new MemoryStream(data);
                dic.Add(Path.GetFileNameWithoutExtension(file), stream);
            }
            foreach (var item in  dic.OrderBy(d=>d.Key))
            {
                // here store item which has been ordered by name!
            }
