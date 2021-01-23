    [TestFixture]
    public class StackQuestionTest
    {
        [Test]
        public void GivenABsonDocumentWithANullForAnPossibleEmbeddedDocument_When_ThenAnInstanceIsSetAsTheEmbeddedDocument()
        {
            BsonSerializer.RegisterSerializationProvider(new VehicleEntryBsonSerializationProvider());
            var document = new BsonDocument()
            {
                {"OtherProperty1", BsonString.Create("12345")},
                {"OtherProperty2", BsonString.Create("67890")},
                {"VehicleEntry", BsonNull.Value},
            };
            var rootObject = BsonSerializer.Deserialize<RootObject>(document);
            Assert.That(rootObject.OtherProperty1, Is.EqualTo("12345"));
            Assert.That(rootObject.OtherProperty2, Is.EqualTo("67890"));
            Assert.That(rootObject.VehicleEntry, Is.Not.Null);
            Assert.That(rootObject.VehicleEntry.What, Is.EqualTo("Magic"));
        }
    }
    public class VehicleEntrySerializer : BsonClassMapSerializer<VehicleEntry>
    {
        public override VehicleEntry Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            if (context.Reader.GetCurrentBsonType() == BsonType.Null)
            {
                context.Reader.ReadNull();
                return new VehicleEntry();
            }
            return base.Deserialize(context, args);
        }
        public VehicleEntrySerializer(BsonClassMap classMap) : base(classMap)
        {
        }
    }
    public class VehicleEntryBsonSerializationProvider : IBsonSerializationProvider
    {
        public IBsonSerializer GetSerializer(Type type)
        {
            if (type == typeof(VehicleEntry))
            {
                BsonClassMap bsonClassMap = BsonClassMap.LookupClassMap(type);
                return new VehicleEntrySerializer(bsonClassMap);
            }
            return null;
        }
    }
    public class RootObject
    {
        public string OtherProperty1 { get; set; }
        public string OtherProperty2 { get; set; }
        public VehicleEntry VehicleEntry { get; set; }
    }
    public class VehicleEntry
    {
        public string What { get; set; } = "Magic";
    }
