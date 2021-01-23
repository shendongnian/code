    [DllImport("Unmanaged.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void UnmanagedModifyGeometry(
        string strFeaId, 
        [In] DPoint3d[] pnts, 
        int iNumPnts
    );
