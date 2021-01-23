        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // Find properties of inherited class
            var classType = value.GetType();
            var classProps = classType.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).ToList();
            // Remove the overrided properties
            classProps.RemoveAll(t =>
            {
                var getMethod = t.GetGetMethod(false);
                return (getMethod.GetBaseDefinition() != getMethod);
            });
            // Get json data
            var o = (JObject)JToken.FromObject(value);
            // Remove all base properties
            foreach (var p in o.Properties().Where(p => !classProps.Select(t => t.Name).Contains(p.Name)).ToList())
                p.Remove();
            o.WriteTo(writer);
        }
