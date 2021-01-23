		[DllImport (MonoTouch.Constants.SystemLibrary)]
		static internal extern int sysctl ([MarshalAs (UnmanagedType.LPArray)] int[] mib, int mibsize, IntPtr output, IntPtr oldLen, IntPtr newp, uint newlen);
		public static Dictionary<String,String> AllMac = null;
		public static String GetMACAddressByIp(String ip)
		{
			return GetMACAddressByIp (ip, false);
		}
		public static String GetMACAddressByIp (String ip, bool reset)
		{
			try 
			{
				if (AllMac == null || reset) 
				{
					AllMac=new Dictionary<string, string>();
					int CTL_NET = 4;
					int PF_ROUTE = 17;
					int AF_INET = 2;
					int NET_RT_FLAGS = 2;
					int RTF_LLINFO = 0x400;
					int[] mib = { CTL_NET, PF_ROUTE, 0, AF_INET, NET_RT_FLAGS, RTF_LLINFO };
					var pLen = Marshal.AllocHGlobal (sizeof(int));
					sysctl (mib, 6, IntPtr.Zero, pLen, IntPtr.Zero, 0);
					var length = Marshal.ReadInt32 (pLen);
					if (length == 0) {
						Marshal.FreeHGlobal (pLen);
						return string.Empty;
					}
					var pBuf = Marshal.AllocHGlobal (length);
					sysctl (mib, 6, pBuf, pLen, IntPtr.Zero, 0);
					int off = 0;
					while (true) {
						short len = Marshal.ReadInt16 (pBuf + off);
						IntPtr paddr = pBuf + off + 36 + 56;
						byte sinlen = Marshal.ReadByte (paddr);  
						uint addr = (uint)Marshal.ReadInt32 (paddr + 4);
						string ipAddress = new IPAddress (BitConverter.GetBytes (addr)).ToString ();
						paddr += sinlen; 
						StringBuilder sb = new StringBuilder ();
						bool allZero = true;
						for (int m = 0; m < 6; m++) {
							byte b = Marshal.ReadByte (paddr + 8 + m);
							if (b != 0) {
								allZero = false;
							}
							if (sb.Length > 0) {
								sb.Append (":");
							}
							sb.Append (b.ToString ("X2"));
						}
						String mac = sb.ToString ();
						if (!allZero) {
							AllMac[ipAddress]=mac;
						}
						off += len;
						if (length <= off) {
							break;
						}
					}
					Marshal.FreeHGlobal (pLen);
					Marshal.FreeHGlobal (pBuf);
				}
				if (AllMac.ContainsKey (ip)) {
					return AllMac [ip];
				}
			} catch (Exception ex) {
				Console.WriteLine ("Exception in GetMACAddressByIp:" + ex.ToString ());
			}
			return "";
		}
