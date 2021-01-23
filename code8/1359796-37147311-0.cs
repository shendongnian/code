        public override bool CanConvert(Type objectType)
        {
            if (objectType == typeof(List<Person>)) return true;
            return false;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            List<Person> persons = new List<Person>();
            JArray personsArray = (JArray)serializer.Deserialize(reader);
            foreach (var personArray in personsArray.Children<JArray>())
            {
                persons.Add(new Person() { 
                             First = personArray[0].Value<string>(),
                             Last = personArray[1].Value<string>(),
                             Age = personArray[2].Value<string>()
                            });
            }
            return persons;
        }
