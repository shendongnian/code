    using System;
    using System.Runtime.InteropServices;
    namespace ComExport
    {
        [ComImport]
        [Guid("EAA4976A-45C3-4BC5-BC0B-E474F4C3C83F")]
        [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
        [TypeIdentifier()]
        public interface ComClass1Interface
        {
            string DoCall();
        }
        [Guid("0D53A3E8-E51A-49C7-944E-E72A2064F938")]
        [ClassInterface(ClassInterfaceType.AutoDual)]
        public class ComClass1 : ComClass1Interface
        {
            public string DoCall()
            {
                return "internal function called";
            }
            public override string ToString()
            {
                return "comclass1.tostring";
            }
        }
    }
