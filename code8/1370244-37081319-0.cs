    <StructLayout(LayoutKind.Sequential, Pack:=4)>
    Public Structure sFMSelectorData
        Public nStructSize As Integer
        <MarshalAs(UnmanagedType.LPStr)>
        Public sGameVersion As String
        ' supplied initial FM root path (the FM Selector may change this)
        <MarshalAs(UnmanagedType.LPStr)>
        Public sRootPath As String
        Public nMaxRootLen As Integer
        ' buffer to copy the selected FM name
        <MarshalAs(UnmanagedType.LPStr)>
        Public sName As String
        Public nMaxNameLen As Integer
        ' set to non-zero when selector Is invoked after game exit (if requested during game start)
        Public bExitedGame As Integer
        ' FM selector should set this to non-zero if it wants to be invoked after game exits (only done for FMs)
        Public bRunAfterGame As Integer
        ' optional list of paths to exclude from mod_path/uber_mod_path in + separated format And Like the config
        ' vars, Or if "*" all Mod paths are excluded (leave buffer empty for no excludes)
        ' the specified exclude paths work as if they had a "*\" wildcard prefix
        <MarshalAs(UnmanagedType.LPStr)>
        Public sModExcludePaths As String
        Public nMaxModExcludeLen As Integer
    End Structure
