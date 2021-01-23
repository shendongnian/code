       [ComImport, Guid("00000122-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IOleDropTarget
    {
        [PreserveSig]
        int OleDragEnter([In, MarshalAs(UnmanagedType.Interface)] object pDataObj, [In, MarshalAs(UnmanagedType.U4)] int grfKeyState, [In, MarshalAs(UnmanagedType.U8)] long pt, [In, Out] ref int pdwEffect);
        [PreserveSig]
        int OleDragOver([In, MarshalAs(UnmanagedType.U4)] int grfKeyState, [In, MarshalAs(UnmanagedType.U8)] long pt, [In, Out] ref int pdwEffect);
        [PreserveSig]
        int OleDragLeave();
        [PreserveSig]
        int OleDrop([In, MarshalAs(UnmanagedType.Interface)] object pDataObj, [In, MarshalAs(UnmanagedType.U4)] int grfKeyState, [In, MarshalAs(UnmanagedType.U8)] long pt, [In, Out] ref int pdwEffect);
    }
    internal class MyDropTarget : IOleDropTarget
    {
        [DllImport("ole32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int RegisterDragDrop(IntPtr hwnd, IOleDropTarget target);
        [DllImport("ole32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern int RevokeDragDrop(IntPtr hwnd);
        public int OleDragEnter(object pDataObj, int grfKeyState, long pt, ref int pdwEffect)
        {
            throw new NotImplementedException();
        }
        public int OleDragOver(int grfKeyState, long pt, ref int pdwEffect)
        {
            throw new NotImplementedException();
        }
        public int OleDragLeave()
        {
            throw new NotImplementedException();
        }
        public int OleDrop(object pDataObj, int grfKeyState, long pt, ref int pdwEffect)
        {
            throw new NotImplementedException();
        }
    }
