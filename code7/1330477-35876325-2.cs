    [System.Runtime.InteropServices.DllImport("ntdll.dll")]
    private static extern int NtQueryInformationProcess(IntPtr processHandle, int processInformationClass, ref NtQueryInformationProcessProcessInformation processInformation, int processInformationLength, ref int returnLength);
    /// <summary>
    /// Return the process ID of the process that is the parent of this process, if any, or else return null.
    /// </summary>
    /// <returns>Return the process ID of the process that is the parent of this process, if any, or else return null.</returns>
    /// <remarks></remarks>
    private static int? GetParentProcessID()
    {
        var info = new NtQueryInformationProcessProcessInformation();
        var returnLength = 0;
        const int ProcessInfoClassProcessBasicInformation = 0;
        var status = NtQueryInformationProcess(Process.GetCurrentProcess().Handle, ProcessInfoClassProcessBasicInformation, ref info, System.Runtime.InteropServices.Marshal.SizeOf(info), ref returnLength);
        var NTStatusSuccess = 0;
        if (status != NTStatusSuccess) throw new System.ComponentModel.Win32Exception(status);
        try
        {
            return Process.GetProcessById(info.InheritedFromUniqueProcessId.ToInt32()).Id;
        }
        catch (ArgumentException)
        {
            return new int?(); //not found.            
        }
    }
    /// <summary>
    /// A structure which is required by the <see cref="NtQueryInformationProcess"/> method.
    /// </summary>
    /// <remarks></remarks>
    private struct NtQueryInformationProcessProcessInformation
    {
        internal IntPtr Reserved1;
        internal IntPtr PebBaseAddress;
        internal IntPtr Reserved2_0;
        internal IntPtr Reserved2_1;
        internal IntPtr UniqueProcessId;
        internal IntPtr InheritedFromUniqueProcessId;
    }
