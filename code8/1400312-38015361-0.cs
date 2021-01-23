    namespace Microsoft.Office.Interop.Excel {
	    [DefaultMember("_Default")]
        [ClassInterface(0)]
        [ComSourceInterfaces("Microsoft.Office.Interop.Excel.AppEvents\0")]
        [Guid("00024500-0000-0000-C000-000000000046")]
        [TypeLibType(2)]
	    [ComImport]
        public class ApplicationClass {
            // ...
            [DispId(302)]
            [MethodImpl(MethodImplOptions.InternalCall)]
            public virtual extern void Quit();
            // ...
        }
    }
