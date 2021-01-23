    public class Response<T>: Newtonsoft.Json.Linq.JObject
    {
        private static string TypeName = (typeof(T)).Name;
        private T _data;
        public T Data {
            get { return _data; }
            set {
                _data = value;
                this[TypeName] = Newtonsoft.Json.Linq.JToken.FromObject(_data);   
            }
        }
    }
