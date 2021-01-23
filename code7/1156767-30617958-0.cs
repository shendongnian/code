    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    
    namespace BrowserExample
    {
        [ComImport, ComVisible(true)]
        [Guid("6d5140c1-7436-11ce-8034-00aa006009fa")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IServiceProvider
        {
            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int QueryService(
                [In] ref Guid guidService,
                [In] ref Guid riid,
                [Out] out IntPtr ppvObject);
        }
    
    }
