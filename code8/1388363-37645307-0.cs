        public IEnumerable<RootObject> ReadAllCities()
        {
            var lines = File.ReadAllLines("list_city.json");
            foreach (var line in lines)
            {
               yield return JsonConvert.DeserializeObject<Rootobject>(line);
            }
        }
