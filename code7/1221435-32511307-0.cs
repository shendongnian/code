            Dictionary<string, List<string>> people = new Dictionary<string, List<string>>();
            while (reader.Read())
            {
                string name = reader.GetString(0);
                string car = reader.GetString(1);
                List<string> cars = null;
                if (!people.TryGetValue(name, out cars))
                {
                    people[name] = cars = new List<string>();
                }
                if (null != car)
                    cars.Add(car);
            }
