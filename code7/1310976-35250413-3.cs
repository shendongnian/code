    using System.Runtime.Serialization;
    
    namespace SerializationTests {
        [DataContract]
        [KnownType(typeof(Delete))]
        public class Delete {
            [DataMember]
            public DeletedStatus Status { get; set; }
        }
    
        [DataContract]
        [KnownType(typeof(DeletedStatus))]
        public class DeletedStatus {
            [DataMember]
            public long Id { get; set; }
            [DataMember]
            public long UserId { get; set; }
        
        }
    
        /**************************************************************
         These types below are what comprise our wrapper class so that we can
         use the JSON in its current state. The wrapper classes have properties that
         are synonymous with the JSON properties.
         **************************************************************/
        //This structure represents the object nesting as it appears currently in your example.
        [DataContract]
        [KnownType(typeof(DeleteJsonResult))]
        public class DeleteWrapperJsonResult {
            [DataMember]
            public DeleteJsonResult delete { get; set; }
        }
    
        [DataContract]
        [KnownType(typeof(DeleteJsonResult))]
        public class DeleteJsonResult {
            [DataMember]
            public DeletedStatusJsonResult status { get; set; }
        }
    
        [DataContract]
        [KnownType(typeof(DeletedStatusJsonResult))]
        public class DeletedStatusJsonResult {
            [DataMember]
            public long id { get; set; }
            [DataMember]
            public string id_str {
                get {
                    return id.ToString();
                }
                set {
                    return;
                }
            }
            [DataMember]
            public long user_id { get; set; }
            [DataMember]
            public string user_id_str {
                get {
                    return user_id.ToString();
                }
                set {
                    return;
                }
            }
        }
    }
