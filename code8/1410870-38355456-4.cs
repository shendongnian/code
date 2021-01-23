            var hash = new System.Collections.Hashtable();
            hash[7] = "7";
            hash[8] = "8";
            var formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            Stream stream = new FileStream(@"C:\SomeFolder\SomeFile.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, hash);
            stream.Close();
