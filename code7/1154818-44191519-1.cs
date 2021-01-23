    const uint NORMAL_PRIORITY_CLASS = 0x0020;
    const uint CREATE_UNICODE_ENVIRONMENT = 0x0400;
    const uint STARTF_USESHOWWINDOW = 0x0001;
    var pInfo = new Common.Helpers.WinAPI.Kernel32.PROCESS_INFORMATION();
    var sInfo = new Common.Helpers.WinAPI.Kernel32.STARTUPINFO();
    sInfo.dwX = (uint)hostingApp.X; // X Position 
    sInfo.dwY = (uint)hostingApp.Y; // Y Position 
    sInfo.dwXSize = (uint)hostingApp.Width; // Width
    sInfo.dwYSize = (uint)hostingApp.Height; // Height
    sInfo.dwFlags = STARTF_USESHOWWINDOW;
    var pSec = new Common.Helpers.WinAPI.Kernel32.SECURITY_ATTRIBUTES();
    var tSec = new Common.Helpers.WinAPI.Kernel32.SECURITY_ATTRIBUTES();
    pSec.nLength = System.Runtime.InteropServices.Marshal.SizeOf(pSec);
    tSec.nLength = System.Runtime.InteropServices.Marshal.SizeOf(tSec);
        
        var create_result = Common.Helpers.WinAPI.Kernel32.CreateProcess(
            fileName,                   // lpApplicationName
            " " + arguments,            // lpCommandLine
            ref pSec,                   // lpProcessAttributes
            ref tSec,                   // lpThreadAttributes
            false,                      // bInheritHandles
            NORMAL_PRIORITY_CLASS | CREATE_UNICODE_ENVIRONMENT,      // dwCreationFlags
            IntPtr.Zero,                // lpEnvironment
            null,                       // lpCurrentDirectory
            ref sInfo,                  // lpStartupInfo
            out pInfo);                 // lpProcessInformation
        
        
        var process = Process.GetProcessById(pInfo.dwProcessId);
