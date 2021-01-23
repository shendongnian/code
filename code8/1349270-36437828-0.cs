            var dic = new Dictionary<string, Dictionary<string, int>>();
            var cities = new Dictionary<string, int>();
            cities.Add("Kiev", 6000000);
            cities.Add("Lviv", 4000000);
            dic.Add("Ukraine", cities);
            var totalPopulationByCountry = dic.ToDictionary(x => x.Key, y => y.Value.Values);
            var sumPopulationByCountry = dic.ToDictionary(x => x.Key, y => y.Value.Values.Sum());
