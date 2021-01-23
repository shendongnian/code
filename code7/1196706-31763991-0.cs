            var json = "{result: { name: \"Joe Doe\", age: 23 }}"; // json format coming back from external url
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("URL");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                dynamic values = JsonConvert.DeserializeObject<dynamic>(content);
                var people = new List<Person>();
                foreach (var item in values.result)
                {
                    var person = new Person
                    {
                        Name = item.name,
                        Age = item.age
                    };
                    people.Add(person);
                }
                return people;
