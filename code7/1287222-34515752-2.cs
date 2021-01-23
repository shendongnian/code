    public class RdfNotificationJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var resultJson = JObject.Load(reader);
            var rdfType = resultJson["$type"].ToObject<string>();
            BaseNotification result;
            switch (rdfType)
            {
                case "App.RRSRC.Feeds.DataAvailable":
                {
                    result = new DataAvailableNotification
                    {
                        SnapshotRevisionId = resultJson["SnapshotRevisionId"].ToObject<string>(),
                        URLs = resultJson["URLs"].ToObject<string[]>()
                    };
                    break;
                }
                case "Service.Feeds.Expired":
                {
                    result = new ExpiredNotification();
                    break;
                }
                default:
                {
                    throw new NotSupportedException();
                }
            }
            result.ChannelId = resultJson["ChannelId"].ToObject<Guid>();
            result.ConsumerId = resultJson["ConsumerId"].ToObject<string>();
            return result;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(BaseNotification);
        }
    }
