    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;
    
    namespace BrowserExample
    {
        [ComVisible(false), ComImport]
        [Guid("988934A4-064B-11D3-BB80-00104B35E7F9")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IDownloadManager
        {
            [return: MarshalAs(UnmanagedType.I4)]
            [PreserveSig]
            int Download(
                [In, MarshalAs(UnmanagedType.Interface)] IMoniker pmk,
                [In, MarshalAs(UnmanagedType.Interface)] IBindCtx pbc,
                [In, MarshalAs(UnmanagedType.U4)] UInt32 dwBindVerb,
                [In] int grfBINDF,
                [In] IntPtr pBindInfo,
                [In, MarshalAs(UnmanagedType.LPWStr)] string pszHeaders,
                [In, MarshalAs(UnmanagedType.LPWStr)] string pszRedir,
                [In, MarshalAs(UnmanagedType.U4)] uint uiCP);
        }
    }
