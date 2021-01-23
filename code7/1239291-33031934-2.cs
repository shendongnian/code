     [Serializable()]
            public class YourCustomException : Exception, ISerializable
            {
                public Int Id { get; set; }
                public Int ErrorCode { get; set; }
                public YourCustomException() : base() { }
                public YourCustomException(string message) : base(message) { }
                public YourCustomException(string message, System.Exception inner) : base(message, inner) { }
                public YourCustomException(SerializationInfo info, StreamingContext context) : base(info, context) { }
                public YourCustomException(string message, int Id, int ErrorCode)
                    : base(message)
                {
                    this.Id = Id;
                    this.ErrorCode = ErrorCode;
                }
            }
