        public static GenericEntity<BaseClass> ConvertToBaseEntity(object model)
        {
            if (model.GetType().GetGenericTypeDefinition() != typeof(GenericEntity<>))
            {
                throw new ArgumentException(
                    "Model should be of type GenericEntity<T>.", "model");
            }
            GenericEntity<BaseClass> baseModel = new GenericEntity<BaseClass>();
            foreach (var propertyInfo in model.GetType().GetProperties())
            {
                baseModel.GetType().GetProperty(propertyInfo.Name).SetValue(baseModel, propertyInfo.GetValue(model));
            }
            return baseModel;
        }
