lang-cs
public void GetDesktopIcons()
{
    // This buffer size will be enough.
    const int BUFFER_SIZE = 0x110;
    // Find window handles via process names.
    IntPtr vHandle = FindWindow("Progman", "Program Manager");
    vHandle = FindWindowEx(vHandle, IntPtr.Zero, "SHELLDLL_DefView", null);
    vHandle = FindWindowEx(vHandle, IntPtr.Zero, "SysListView32", "FolderView");
    // TODO: Do error handling.
    if (vHandle == IntPtr.Zero) {
        return;
    }
    // Count subwindows of desktop => count of icons.
    int vIconCount = (int) NativeMethods.SendMessage(desktopWindowHandle, NativeMethods.LVM.GETITEMCOUNT, IntPtr.Zero, IntPtr.Zero);
    // Get the desktop window's process to enumerate child windows.
    NativeMethods.GetWindowThreadProcessId(desktopWindowHandle, out uint vProcessId);
    IntPtr vProcess = NativeMethods.OpenProcess(NativeMethods.PROCESS_VM.OPERATION | NativeMethods.PROCESS_VM.READ | NativeMethods.PROCESS_VM.WRITE, false, vProcessId);
    // Allocate memory in the desktop process.
    IntPtr vPointer = VirtualAllocEx(vProcess, IntPtr.Zero, new UintPtr(BUFFER_SIZE), MEM_RESERVE | MEM_COMMIT, PAGE_READWRITE);
    // Initialize loop variables.
    NativeMethods.LVITEMA currentDesktopIcon = new NativeMethods.LVITEMA();
    byte[] vBuffer = new byte[BUFFER_SIZE];
    uint bytesRead = 0;
    // Instantiate an item to write to the remote buffer and be filled out there.
    NativeMethods.LVITEMA[] remoteBufferDesktopIcon = new NativeMethods.LVITEMA[1];
    // Initialize basic structure.
    // We want to get the icon's text, so set the mask accordingly.
    remoteBufferDesktopIcon[0].mask = NativeMethods.LVIF.TEXT;
    // Set maximum text length to buffer length minus offset used in pszText.
    remoteBufferDesktopIcon[0].cchTextMax = vBuffer.Length - Marshal.SizeOf(typeof(NativeMethods.LVITEMA));
    // Set pszText at point after this structure in the remote process's buffer.
    remoteBufferDesktopIcon[0].pszText = (IntPtr) ((int) bufferPointer + Marshal.SizeOf(typeof(NativeMethods.LVITEMA)));
    try
    {
        // Loop through available desktop icons.
        for (int i = 0; i < iconCount; i++)
        {
            remoteBufferDesktopIcon[0].iItem = i;
            // Write to desktop process the structure we want to get.
            NativeMethods.WriteProcessMemory(desktopProcessHandle, bufferPointer, Marshal.UnsafeAddrOfPinnedArrayElement(remoteBufferDesktopIcon, 0), new UIntPtr((uint) Marshal.SizeOf(typeof(NativeMethods.LVITEMA))), ref bytesRead);
            // Get i-th item of desktop and read its memory.
            NativeMethods.SendMessage(desktopWindowHandle, NativeMethods.LVM.GETITEMW, new IntPtr(i), bufferPointer);
            NativeMethods.ReadProcessMemory(desktopProcessHandle, bufferPointer, Marshal.UnsafeAddrOfPinnedArrayElement(vBuffer, 0), new UIntPtr((uint) Marshal.SizeOf(currentDesktopIcon)), ref bytesRead);
            // TODO: Error handling. This error is really unlikely.
            if (bytesRead != Marshal.SizeOf(currentDesktopIcon))
            {
                throw new Exception("Read false amount of bytes.");
            }
            // Get actual struct filled from buffer.
            currentDesktopIcon = Marshal.PtrToStructure<NativeMethods.LVITEMA>(Marshal.UnsafeAddrOfPinnedArrayElement(vBuffer, 0));
            // Use the now set pszText pointer to read the icon text into the buffer. Maximum length is 260, more characters won't be displayed.
            NativeMethods.ReadProcessMemory(desktopProcessHandle, currentDesktopIcon.pszText, Marshal.UnsafeAddrOfPinnedArrayElement(vBuffer, 0), new UIntPtr(260), ref bytesRead);
            // Read from buffer into string with unicode encoding, then trim string.
            currentIconTitle = Encoding.Unicode.GetString(vBuffer, 0, (int) bytesRead);
            currentIconTitle = currentIconTitle.Substring(0, currentIconTitle.IndexOf('\0'));
            // TODO: Do something with the icon title.
        }
    }
    finally
    {
        // Clean up unmanaged memory.
        NativeMethods.VirtualFreeEx(vProcess, bufferPointer, UIntPtr.Zero, NativeMethods.MEM.RELEASE);
        NativeMethods.CloseHandle(vProcess);
    }
Here is the `LVITEMA` struct I used in NativeMethods:
lang-cs
[StructLayout(LayoutKind.Sequential)]
internal struct LVITEMA
{
    public int mask;
    public int iItem;
    public int iSubItem;
    public int state;
    public int stateMask;
    public IntPtr pszText;
    public int cchTextMax;
    public int iImage;
    public IntPtr lParam;
    public int iIndent;
    public uint iGroupId;
    public UIntPtr puColumns;
}
