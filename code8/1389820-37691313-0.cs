    public class Foo
    {
        const string barName = "bar";
        [JsonIgnore]
        public int? Bar { get; set; }
        [JsonExtensionData]
        public Dictionary<string, object> Catchall;
        [OnSerializing]
        void OnSerializing(StreamingContext ctx)
        {
            if (Catchall == null)
                Catchall = new Dictionary<string, object>();
            if (Bar != null)
                Catchall[barName] = Bar.Value;
        }
        [OnSerialized]
        void OnSerialized(StreamingContext ctx)
        {
            if (Catchall != null)
                Catchall.Remove(barName);
        }
        [OnDeserialized]
        void OnDeserializedMethod(StreamingContext context)
        {
            if (Catchall != null)
            {
                object value;
                if (Catchall.TryGetValue(barName, out value))
                {
                    try
                    {
                        if (value == null)
                        {
                            Bar = null;
                        }
                        else
                        {
                            Bar = (int)JToken.FromObject(value);
                        }
                        Catchall.Remove(barName);
                    }
                    catch (Exception)
                    {
                        Debug.WriteLine(string.Format("Value \"{0}\" of {1} was not an integer", value, barName));
                    }
                }
            }
        }
    }
