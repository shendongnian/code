    [DataContract(Name = "ResponseOf{0}")]
        [KnownType("GetKnownTypes")]
        public class Response<T>
            where T : class
        {
    
            public static Type[] GetKnownTypes()
            {
                var type = typeof(IDataContract);
                var types = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes())
                    .Where(p => type.IsAssignableFrom(p));
    
                return types.ToArray();
            }
    
            [DataMember(Name = "status")]
            public ResponseStatus ResponseStatus { get; set; }
    
            [DataMember(Name = "data")]
            public object Data { get; set; }
    
            public Response()
            {
                ResponseStatus = ResponseStatus.Success;
            }
    
            public Response(T data) : base()
            {
                Data = data;            
            }
        }
