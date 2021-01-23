            BaseClass d1 = new Derived1 {Age = 23};
            GenericEntity<BaseClass> entity = new GenericEntity<BaseClass> {Property = d1};
            var data = JsonConvert.SerializeObject(entity, new JsonSerializerSettings() {
                TypeNameHandling = TypeNameHandling.All
            });
            var baseEntity = JsonConvert.DeserializeObject<GenericEntity<Derived1>>(data, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            });
