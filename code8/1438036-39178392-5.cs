            var s = "[{\"name\": \"Field1\", \"results\": [\"One\", \"Two\", \"Three\"]}, {\"name\": \"Field2\", \"results\": [\"One\", \"Two\", \"Three\", \"Four\"]}]";
            List<Output> data = JsonConvert.DeserializeObject<List<Output>>(s);
            DataTable dt = new DataTable(); 
            using (var reader = ObjectReader.Create(data))
            {
                dt.Load(reader);
            }
