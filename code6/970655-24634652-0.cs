    public class Program
	{
        public static void Main(string[] args)
		{
			using (var mp = ProcessManipulator.Start("test1.exe", null,
				ProcessCreationFlags.CREATE_BREAKAWAY_FROM_JOB | 
				ProcessCreationFlags.CREATE_SUSPENDED, null, "5.txt"))
			{
				mp.Resume();
			}
        }
    }
    [Flags]
	public enum ProcessCreationFlags : uint
	{
		ZERO_FLAG = 0x00000000,
		CREATE_BREAKAWAY_FROM_JOB = 0x01000000,
		CREATE_DEFAULT_ERROR_MODE = 0x04000000,
		CREATE_NEW_CONSOLE = 0x00000010,
		CREATE_NEW_PROCESS_GROUP = 0x00000200,
		CREATE_NO_WINDOW = 0x08000000,
		CREATE_PROTECTED_PROCESS = 0x00040000,
		CREATE_PRESERVE_CODE_AUTHZ_LEVEL = 0x02000000,
		CREATE_SEPARATE_WOW_VDM = 0x00001000,
		CREATE_SHARED_WOW_VDM = 0x00001000,
		CREATE_SUSPENDED = 0x00000004,
		CREATE_UNICODE_ENVIRONMENT = 0x00000400,
		DEBUG_ONLY_THIS_PROCESS = 0x00000002,
		DEBUG_PROCESS = 0x00000001,
		DETACHED_PROCESS = 0x00000008,
		EXTENDED_STARTUPINFO_PRESENT = 0x00080000,
		INHERIT_PARENT_AFFINITY = 0x00010000
	}
	public class ProcessManipulator : IDisposable
	{
		private IntPtr _primaryThread;
		private bool _disposed = false;
		private ProcessManipulator(IntPtr primaryThread)
		{
			_primaryThread = primaryThread;
		}
		public Process ManipulatedProcess { get; private set; }
		[StructLayout(LayoutKind.Sequential)]
		private struct PROCESS_INFORMATION
		{
			public IntPtr hProcess;
			public IntPtr hThread;
			public int dwProcessId;
			public int dwThreadId;
		}
		[StructLayout(LayoutKind.Sequential)]
		private struct SECURITY_ATTRIBUTES
		{
			public UInt32 nLength;
			public IntPtr lpSecurityDescriptor;
			public Int32 bInheritHandle;
		}
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		private struct STARTUPINFO
		{
			public Int32 cb;
			public string lpReserved;
			public string lpDesktop;
			public string lpTitle;
			public Int32 dwX;
			public Int32 dwY;
			public Int32 dwXSize;
			public Int32 dwYSize;
			public Int32 dwXCountChars;
			public Int32 dwYCountChars;
			public Int32 dwFillAttribute;
			public Int32 dwFlags;
			public Int16 wShowWindow;
			public Int16 cbReserved2;
			public IntPtr lpReserved2;
			public IntPtr hStdInput;
			public IntPtr hStdOutput;
			public IntPtr hStdError;
		}
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool CreateProcess(string lpApplicationName, string lpCommandLine, IntPtr lpProcessAttributes,
			IntPtr lpThreadAttributes,
			bool bInheritHandles, uint dwCreationFlags, IntPtr lpEnvironment,
			string lpCurrentDirectory, ref STARTUPINFO lpStartupInfo, out PROCESS_INFORMATION lpProcessInformation);
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern bool CloseHandle(IntPtr hObject);
		/// <summary>
		/// Decrements a thread's suspend count. When the suspend count is decremented to zero, the execution of the thread is resumed.
		/// </summary>
		/// <param name="hThread">A handle to the thread to be restarted.</param>
		/// <returns>If the function succeeds, the return value is the thread's previous suspend count. If the function fails, the return value is -1.</returns>
		[DllImport("kernel32.dll", SetLastError = true)]
		private static extern int ResumeThread(IntPtr hThread);
		public void Resume()
		{
			if (ResumeThread(_primaryThread) == -1)
				throw new Exception(string.Format("Unable to resume the thread.  Error: {0}", Marshal.GetLastWin32Error()));
		}
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall, SetLastError = true)]
		public static extern IntPtr CreateFile(
			string lpFileName,
			uint dwDesiredAccess,
			uint dwShareMode,
			IntPtr SecurityAttributes,
			uint dwCreationDisposition,
			uint dwFlagsAndAttributes,
			IntPtr hTemplateFile
		);
		private const int GENERIC_WRITE = 0x40000000;
		private const int FILE_SHARE_READ = 0x00000001;
		private const int FILE_SHARE_WRITE = 2;
		private const int CREATE_NEW = 1;
		private const int FILE_ATTRIBUTE_NORMAL = 128;
		private static IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
		
		private static IntPtr PrepareLogFile(string fileName)
		{
			var length = Marshal.SizeOf(typeof(SECURITY_ATTRIBUTES));
			var securityAttributes = new SECURITY_ATTRIBUTES()
			{
				nLength = (uint)length,
				lpSecurityDescriptor = IntPtr.Zero,
				bInheritHandle = 1
			};
			var securityAttributesPtr = Marshal.AllocHGlobal(length);
			try
			{
				Marshal.StructureToPtr(securityAttributes, securityAttributesPtr, false);
				var hLogFile = CreateFile(fileName,
					GENERIC_WRITE,
					FILE_SHARE_READ | FILE_SHARE_WRITE,
					securityAttributesPtr,
					CREATE_NEW,
					FILE_ATTRIBUTE_NORMAL,
					IntPtr.Zero);
				if (hLogFile == INVALID_HANDLE_VALUE)
					throw new Exception(string.Format("Unable to create a log file.  Error: {0}", Marshal.GetLastWin32Error()));
				return hLogFile;
			}
			finally
			{
				Marshal.FreeHGlobal(securityAttributesPtr);
			}
		}
		
		[Flags]
		private enum STARTF : uint
		{
			STARTF_USESHOWWINDOW = 0x00000001,
			STARTF_USESIZE = 0x00000002,
			STARTF_USEPOSITION = 0x00000004,
			STARTF_USECOUNTCHARS = 0x00000008,
			STARTF_USEFILLATTRIBUTE = 0x00000010,
			STARTF_RUNFULLSCREEN = 0x00000020,  // ignored for non-x86 platforms
			STARTF_FORCEONFEEDBACK = 0x00000040,
			STARTF_FORCEOFFFEEDBACK = 0x00000080,
			STARTF_USESTDHANDLES = 0x00000100,
		}
		/// <summary>
		/// Allows to create child process specifing creation flags.
		/// </summary>
		/// <param name="fileName">Path to the executable module</param>
		/// <param name="args">Arguments</param>
		/// <param name="creationFlags">Process creation flags</param>
		/// <param name="currentDirectory">Current directory</param>
		/// <param name="logFileName">File for output redirection</param>
		public static ProcessManipulator Start(string fileName, string args, ProcessCreationFlags creationFlags,
			string currentDirectory, string logFileName)
		{
			var hLogFile = PrepareLogFile(logFileName);
			try
			{
				return Start(fileName, args, creationFlags, currentDirectory, hLogFile);
			}
			finally
			{
				CloseHandle(hLogFile);
			}
		}
		
		private static ProcessManipulator Start(string fileName, string args, ProcessCreationFlags creationFlags, string currentDirectory, IntPtr hOutRedirection)
		{
			var startupInfo = new STARTUPINFO
			{
				cb = Marshal.SizeOf(typeof(STARTUPINFO)),
				hStdError = hOutRedirection,
				hStdOutput = hOutRedirection,
				dwFlags = hOutRedirection != IntPtr.Zero ? (int)STARTF.STARTF_USESTDHANDLES : 0
			};
			var processInfo = new PROCESS_INFORMATION();
			if (!CreateProcess(fileName,
				String.Format("{0} {1}", Path.GetFileName(fileName), args),
				IntPtr.Zero,
				IntPtr.Zero,
				hOutRedirection != IntPtr.Zero,
				(uint)creationFlags,
				IntPtr.Zero,
				currentDirectory,
				ref startupInfo,
				out processInfo))
				throw new Exception(string.Format("Unable to create a process.  Error: {0}", Marshal.GetLastWin32Error()));
			//GetProcessById() open new handle for the process so current must be closed as useless
			if (!CloseHandle(processInfo.hProcess))
				throw new Exception(string.Format("Unable to close the process handle.  Error: {0}", Marshal.GetLastWin32Error()));
			return new ProcessManipulator(processInfo.hThread)
			{
				ManipulatedProcess = Process.GetProcessById(processInfo.dwProcessId)
			};
		}
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		private void Dispose(bool disposing)
		{
			if (_disposed)
				return;
			if (disposing)
			{
				//dispose managed disposable resources
				ManipulatedProcess.Dispose();
			}
			var result = CloseHandle(_primaryThread);
			_primaryThread = IntPtr.Zero;
			//if (!result)
			//	throw new Exception(string.Format("Unable to close the job object handle.  Error: {0}", Marshal.GetLastWin32Error()));
			_disposed = true;
		}
		~ProcessManipulator()
		{
			Dispose(false);
		}
    }
