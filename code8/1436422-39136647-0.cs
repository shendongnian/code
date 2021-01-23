    public class Payload<T> : Newtonsoft.Json.Linq.JObject  {
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
     //Response is a pre-existing class...
    public class Response<T>: Response { 
        private Payload<T> Value;
        public Response(T arg)  {
            Value = new Payload<T>() { Data = arg };            
        }
        public static implicit operator JObject(Response<T> arg) {
            return arg.Value;
        }
        public string Serialize() {
            return Value.ToString();
        }
    }
