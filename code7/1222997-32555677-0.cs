	public sealed class SafeFindHandle : SafeHandleZeroOrMinusOneIsInvalid
	{
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		[DllImport("kernel32.dll")]
		private static extern bool FindClose(IntPtr handle);
		[SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
		internal SafeFindHandle()
			: base(true)
		{ }
		protected override bool ReleaseHandle()
		{
            if (IsInvalid || IsClosed)
                return true;
			return FindClose(base.handle);
		}
	}
	public static class FileEnumerator
	{
		[Serializable, StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto), BestFitMapping(false)]
		internal class WIN32_FIND_DATA
		{
			public FileAttributes dwFileAttributes;
			public uint ftCreationTime_dwLowDateTime;
			public uint ftCreationTime_dwHighDateTime;
			public uint ftLastAccessTime_dwLowDateTime;
			public uint ftLastAccessTime_dwHighDateTime;
			public uint ftLastWriteTime_dwLowDateTime;
			public uint ftLastWriteTime_dwHighDateTime;
			public uint nFileSizeHigh;
			public uint nFileSizeLow;
			public int dwReserved0;
			public int dwReserved1;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			public string cFileName;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
			public string cAlternateFileName;
		}
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern SafeFindHandle FindFirstFile(string fileName,
			[In, Out] WIN32_FIND_DATA data);
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern bool FindNextFile(SafeFindHandle hndFindFile,
			[In, Out, MarshalAs(UnmanagedType.LPStruct)] WIN32_FIND_DATA lpFindFileData);
		public static IEnumerable<string> EnumerateFiles(string path)
		{
			WIN32_FIND_DATA finddata = new WIN32_FIND_DATA();
			Queue<string> paths = new Queue<string>();
			paths.Enqueue(path);
			while (paths.Count > 0)
			{
				var nxtpath = paths.Dequeue();
				using (var fh = FindFirstFile(Path.Combine(nxtpath, "*"), finddata))
				{
					if (fh.IsInvalid)
						continue;
					bool ok = true;
					while (ok)
					{
						if ((finddata.dwFileAttributes & FileAttributes.Directory) == FileAttributes.Directory)
						{
							if (finddata.cFileName != "." && finddata.cFileName != "..")
								paths.Enqueue(Path.Combine(nxtpath, finddata.cFileName));
						}
						else
							yield return Path.Combine(nxtpath, finddata.cFileName);
						ok = FindNextFile(fh, finddata);
					}
				}
			}
		}
	}
