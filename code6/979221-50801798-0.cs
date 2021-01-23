    using System;
    using System.Runtime.InteropServices;
    
    namespace EncryptionCOMTool
    {
        [ComVisible(visibility:true)]
        [Guid(guid: "4a69e3ce-7cf8-4985-9b1a-def7977a95e7")]
        [ProgId(progId: "EncryptionCOMTool.EncryptDecrypt")]
        [ClassInterface(classInterfaceType: ClassInterfaceType.None)]
        public class EncryptDecrypt
        {
            public EncryptDecrypt()
            {
    
            }
    
            public string Encrypt(string input)
            {
                return "some encrypted value";
            }
    
            public string Decrypt(string input)
            {
                return "some decrypted value";
            }
        }
    }
