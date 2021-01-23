        protected XmlException(SerializationInfo info, StreamingContext context) : base(info, context) {
            res                 = (string)  info.GetValue("res"  , typeof(string));
            args                = (string[])info.GetValue("args", typeof(string[]));
            lineNumber          = (int)     info.GetValue("lineNumber", typeof(int));
            linePosition        = (int)     info.GetValue("linePosition", typeof(int));
 
            // deserialize optional members
            sourceUri = string.Empty;
            string version = null;
            foreach ( SerializationEntry e in info ) {
                switch ( e.Name ) {
                    case "sourceUri":
                        sourceUri = (string)e.Value;
                        break;
                    case "version":
                        version = (string)e.Value;
                        break;
                }
            }
 
