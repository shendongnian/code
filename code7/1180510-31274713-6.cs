     class ByteArrayParser : IObjectParser {
         public object Parse(object obj, propertyName string) {
             var bytes = obj as byte[];
             // we've tunneled multiple parameters in the propertyName string
             var nameParameters = propertyName.Split(":");
             // note we've lost our strong typing, and coupled ourselves to the propertyName format
             int index = int.Parse(nameParameters[0]);
             string readAsType = nameParameters[1];
             using (var ms = new MemoryStream(bytes))
             using (var br = new BinaryReader(ms))
             {
                 ms.Position = index;
                 switch (readAsType) {
                     case "float":
                         return br.ReadSingle();
                     case "int":
                         return br.ReadInt32();
                     case "string"
                         // we can even have yet another parameter only in special cases
                         if (nameParameters.Length > 2) {
                            // it's an ASCII string
                            int stringLength = int.Parse(nameParameters[2]);
                            return Encoding.ASCII.GetString(br.ReadBytes(stringLength));
                         } else {
                            // it's BinaryReader's native length-prefixed string
                            return br.ReadString();
                         }
                   default:
                         // we don't know that type
                        throw new ArgumentOutOfRangeException("type");
                 }
             }
         }
     }
     
