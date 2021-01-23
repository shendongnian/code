    using System;
    using System.Web.Script.Serialization;
    using SQLite.Extensions.TextBlob;
    public class BlobSerializer : ITextBlobSerializer
    {
        private readonly JavaScriptSerializer serializer = new JavaScriptSerializer();
        public string Serialize(object element)
        {
            var str = serializer.Serialize(element);
            return str;
        }
        public object Deserialize(string text, Type type)
        {
            var result = serializer.Deserialize(text, type);
            return result;
        }
    }
