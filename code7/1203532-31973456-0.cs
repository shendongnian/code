    public static class ObjectExtensions
    {
        public static void CopyFrom<TTo, TFrom>(this TTo target, TFrom source) where TTo : class
        {
            if (target == null)
                throw new ArgumentNullException();
            // Preserve object graph structure and handle polymorphic fields.
            var settings = new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.All, ReferenceLoopHandling = ReferenceLoopHandling.Serialize, TypeNameHandling = TypeNameHandling.Auto };
            var json = JsonConvert.SerializeObject(source, settings);
            JsonConvert.PopulateObject(json, target, settings);
        }
    }
