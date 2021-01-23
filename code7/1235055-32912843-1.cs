    using (var st = new StreamReader(@"sample1.json"))
    {
        string Json = st.ReadToEnd();
        List<List<TVID>> IdListList = JsonConvert.DeserializeObject<List<List<TVID>>>(Json);
        foreach (var IdList in IdListList)
        {
            foreach (var ids in IdList)
            {
                Console.WriteLine(ids.ID);
                foreach (var myphoto in ids.photos)
                {
                    Console.WriteLine(myphoto.Photo + "," + myphoto.Photo_order + "," +
                                      myphoto.Caption);
                    Console.Read();
                }
            }
        }
    }
