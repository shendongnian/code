        BsonClassMap.RegisterClassMap<MyModel>(cm =>
        {
            cm.AutoMap();
            cm.MapIdProperty(c => c.MyModelId)
                    .SetIgnoreIfDefault(true) //added this line
                    .SetIdGenerator(StringObjectIdGenerator.Instance)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId));
        });
