    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)>
    Public Structure DevMode
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)>
        Public DeviceName As String
        Public SpecVersion As Short
        Public DriverVersion As Short
        Public Size As Short
        Public DriverExtra As Short
        Public Fields As Integer
        Public Mode As DeviceMode
        Public Color As Short
        Public Duplex As Short
        Public YResolution As Short
        Public TTOption As Short
        Public Collate As Short
        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)>
        Public FormName As String
        Public LogPixels As Short
        Public BitsPerPixel As Integer
        Public PixelsWidth As Integer
        Public PixelsHeight As Integer
        Public Flags As DeviceFlags
        Public DisplayFrequency As Integer
        Public IcmMethod As Integer
        Public IcmIntent As Integer
        Public MediaType As Integer
        Public DitherType As Integer
        Public Reserved1 As Integer
        Public Reserved2 As Integer
        Public PanningWidth As Integer
        Public PanningHeight As Integer
    End Structure
    <StructLayout(LayoutKind.Explicit)>
    Public Structure DeviceMode
        <FieldOffset(0)> Public PrinterDevMode As PrinterDevMode
        <FieldOffset(0)> Public DisplayDevMode As DisplayDevMode
    End Structure
    <StructLayout(LayoutKind.Explicit)>
    Public Structure DeviceFlags
        <FieldOffset(0)> Public DisplayFlags As Integer
        <FieldOffset(0)> Public Nup As Integer
    End Structure
    <StructLayout(LayoutKind.Sequential)>
    Public Structure PrinterDevMode
        Public Orientation As Short
        Public PaperSize As Short
        Public PaperLength As Short
        Public PaperWidth As Short
        Public Scale As Short
        Public Copies As Short
        Public DefaultSource As Short
        Public PrintQuality As Short
    End Structure
    <StructLayout(LayoutKind.Sequential)>
    Public Structure DisplayDevMode
        Public Position As Win32.Types.Point ' 8 bytes.
        Public DisplayOrientation As Integer
        Public DisplayFixedOutput As Integer
    End Structure
