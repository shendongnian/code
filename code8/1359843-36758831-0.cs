        public object GetObject(ClassWithManyPropererties obj)
        {
            var props = obj.GetType().GetProperties().Where(p => p.Name.Contains("PropertyNameYear")).ToList();
            dynamic returnObject = new ExpandoObject() as IDictionary<string, Object>;
            foreach (var property in props)
            {
                returnObject.Add(property.Name, property.GetValue(obj));
            }
            return returnObject;
        }
