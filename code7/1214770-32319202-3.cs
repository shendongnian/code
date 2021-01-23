    namespace ConsoleApplication2
    {
        public partial class MySoapResponse
        {
            MyDOM.Root Document { get; }
            internal MySoapResponse(MyDOM.Root document)
            {
                Document = document;
            }
            internal string ResponseCode()
            {
                return Document.childA.ResponseCode;
            }
            internal string ReasonCode()
            {
                return Document.childA.ReasonCode;
            }
        }
    }
