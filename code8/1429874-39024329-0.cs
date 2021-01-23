        private ProcessOwnerInformation GetProcessOwnerInformation(uint processId)
        {
            WindowsIdentity _user = WindowsIdentity.GetCurrent();
            string stringSID = string.Empty;
            string process = ExGetProcessInfoByPID((int)processId, out stringSID);
            bool bIgnoreCase = true;
            ProcessOwnerInformation retval = new ProcessOwnerInformation();
            bool bOwnsProcess = string.Compare(stringSID, _user.User.Value, bIgnoreCase) == 0;
            if(bOwnsProcess)
            {
                retval.procID = processId;
                retval.OwnsProcess = bOwnsProcess;
                retval.SID = stringSID;
            }
            return retval;
        }
        public const int TOKEN_QUERY = 0X00000008;
        const int ERROR_NO_MORE_ITEMS = 259;
        enum TOKEN_INFORMATION_CLASS
        {
            TokenUser = 1,
            TokenGroups,
            TokenPrivileges,
            TokenOwner,
            TokenPrimaryGroup,
            TokenDefaultDacl,
            TokenSource,
            TokenType,
            TokenImpersonationLevel,
            TokenStatistics,
            TokenRestrictedSids,
            TokenSessionId
        }
        [StructLayout(LayoutKind.Sequential)]
        struct TOKEN_USER
        {
            public _SID_AND_ATTRIBUTES User;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct _SID_AND_ATTRIBUTES
        {
            public IntPtr Sid;
            public int Attributes;
        }
        [DllImport("advapi32")]
        static extern bool OpenProcessToken(
            IntPtr ProcessHandle, // handle to process
            int DesiredAccess, // desired access to process
            ref IntPtr TokenHandle // handle to open access token
        );
        [DllImport("kernel32")]
        static extern IntPtr GetCurrentProcess();
        [DllImport("advapi32", CharSet = CharSet.Auto)]
        static extern bool GetTokenInformation(
            IntPtr hToken,
            TOKEN_INFORMATION_CLASS tokenInfoClass,
            IntPtr TokenInformation,
            int tokeInfoLength,
            ref int reqLength
        );
        [DllImport("kernel32")]
        static extern bool CloseHandle(IntPtr handle);
        [DllImport("advapi32", CharSet = CharSet.Auto)]
        static extern bool ConvertSidToStringSid(
            IntPtr pSID,
            [In, Out, MarshalAs(UnmanagedType.LPTStr)] ref string pStringSid
        );
        [DllImport("advapi32", CharSet = CharSet.Auto)]
        static extern bool ConvertStringSidToSid(
            [In, MarshalAs(UnmanagedType.LPTStr)] string pStringSid,
            ref IntPtr pSID
        );
        public static bool DumpUserInfo(IntPtr pToken, out IntPtr SID)
        {
            int Access = TOKEN_QUERY;
            IntPtr procToken = IntPtr.Zero;
            bool ret = false;
            SID = IntPtr.Zero;
            try
            {
                if (OpenProcessToken(pToken, Access, ref procToken))
                {
                    ret = ProcessTokenToSid(procToken, out SID);
                    CloseHandle(procToken);
                }
                return ret;
            }
            catch (Exception err)
            {
                return false;
            }
        }
        private static bool ProcessTokenToSid(IntPtr token, out IntPtr SID)
        {
            TOKEN_USER tokUser;
            const int bufLength = 256;
            IntPtr tu = Marshal.AllocHGlobal(bufLength);
            bool ret = false;
            SID = IntPtr.Zero;
            try
            {
                int cb = bufLength;
                ret = GetTokenInformation(token, TOKEN_INFORMATION_CLASS.TokenUser, tu, cb, ref cb);
                if (ret)
                {
                    tokUser = (TOKEN_USER)Marshal.PtrToStructure(tu, typeof(TOKEN_USER));
                    SID = tokUser.User.Sid;
                }
                return ret;
            }
            catch (Exception err)
            {
                return false;
            }
            finally
            {
                Marshal.FreeHGlobal(tu);
            }
        }
        public static string ExGetProcessInfoByPID(int PID, out string SID)//, out string OwnerSID)
        {
            IntPtr _SID = IntPtr.Zero;
            SID = String.Empty;
            try
            {
                Process process = Process.GetProcessById(PID);
                if (DumpUserInfo(process.Handle, out _SID))
                {
                    ConvertSidToStringSid(_SID, ref SID);
                }
                return process.ProcessName;
            }
            catch
            {
                return "Unknown";
            }
        }
