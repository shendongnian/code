        for (int i = 1; i < 149; i++)
        {
            using (var stream1 = new FileStream(path + @"\" + i + ".zip", FileMode.Open, FileAccess.Read))
            {
                using (var reader = new BinaryReader(stream1))
                {
                    //list_.Add(reader.ReadBytes((int)stream1.Length));
                    //Instead of adding that to list, write them to disk here
                    //using (FileStream fs = File.Create(filePaths_))
                    //...
                    stream1.Close();//No need for this, using is going to call it. 
                    stream1.Dispose();//No need for this, using is going to call it. 
                    reader.Close();//No need for this, using is going to call it. 
                    reader.Dispose();//No need for this, using is going to call it. 
                }
            }
        }
