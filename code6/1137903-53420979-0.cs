            var list = new List<string>();
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "XYZ.ABC.Resources.MyTextFile.txt";
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    list.Add(reader.ReadLine());
                }
            }
            return list;
