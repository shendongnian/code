            List<Output> data = JsonConvert.DeserializeObject<List<Output>>(sr.ReadToEnd());
            DataTable dt = new DataTable(); 
            using (var reader = ObjectReader.Create(data))
            {
                dt.Load(reader);
            }
