    using MongoDB.Bson;
    using MongoDB.Bson.Serialization;
    using MongoDB.Bson.Serialization.Serializers;
    using MongoDB.Driver;
    class Program
    {
        static void Main(string[] args)
        {
            BsonSerializer.RegisterSerializer(new MySerializer());
            var client = new MongoClient();
            var database = client.GetDatabase("test");
            var collection = database.GetCollection<A>("upsertArray");
            var docs = collection.Find(new BsonDocument()).ToList();
        }
    }
    class A
    {
        public int[] Arr { get; set; }
        public ObjectId Id { get; set; }
    }
    class MySerializer : SerializerBase<A>
    {
        public override A Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var doc = BsonDocumentSerializer.Instance.Deserialize(context);
            var ints = new int[5];
            var arr = doc["arr"];
            if (arr.IsBsonArray)
            {
                var array = arr.AsBsonArray;
                for (var i = 0; i < 5; i++)
                {
                    if (i < array.Count)
                    {
                        ints[i] = array[i].AsInt32;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                ints[0] = arr.AsInt32;
            }
            return new A { Arr = ints, Id = doc["_id"].AsObjectId };
        }
    }
