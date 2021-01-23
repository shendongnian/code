    This is a proof of how to serialize / deserialize an object using BinaryFormatter:
    List<String> ls = new List<string>();
            ls.Add("aaa");
            ls.Add("Bb");
            BinaryFormatter bf = new BinaryFormatter ();
            var fileName = Guid.NewGuid ().ToString ().Replace ("-","");
            var path = Path.Combine (Environment.GetFolderPath (Environment.SpecialFolder.CommonApplicationData), fileName);
            try
            {
                using (var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    bf.Serialize(fs, ls);
                }
                using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    ls = bf.Deserialize(fs) as List<String>;
                }
            }
            finally
            {
                if (File.Exists (path))
                {
                    try
                    {
                        File.Delete(path);
                    }
                    catch
                    {
                    }
                }
            }
