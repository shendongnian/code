    public string coutryNames()
        {
            List<Country> list = new List<Country>();
            List.Add(new Country {Id = 92, Name = "Pakistan"});
            //etc
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(list);
        }
