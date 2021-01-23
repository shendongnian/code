    private class MongoObjectIdSpecimenBuilder : ISpecimenBuilder
        {
            public object Create(object request, ISpecimenContext context)
            {
                if (request is PropertyInfo info
                    && info.PropertyType == typeof(ObjectId)
                    && ...)
                    return ObjectId.GenerateNewId().ToString();
                return new NoSpecimen();
            }
        }
    // register the builder
    AutoFixture.Customizations.Add(new MongoObjectIdSpecimenBuilder());
