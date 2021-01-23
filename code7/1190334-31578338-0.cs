    [DllImport(
        "TEST_DLL.dll",
        CallingConvention = CallingConvention.Cdecl,
        CharSet = CharSet.Ansi,
        SetLastError = true
    )]
    public static extern void result(
        string sString,
        StringBuilder response,
        int cchResponse
    );
    StringBuilder buffer( 10 );
    result( "This is my input string", buffer, buffer.Capacity );
