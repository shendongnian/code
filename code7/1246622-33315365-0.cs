    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Runtime.InteropServices;
    
    class MainConsole
    {
        [DllImport("Netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern int NetShareGetInfo(
            [MarshalAs(UnmanagedType.LPWStr)] string serverName,
            [MarshalAs(UnmanagedType.LPWStr)] string netName,
            Int32 level,
            out IntPtr bufPtr);
    
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetSecurityDescriptorDacl(
            IntPtr pSecurityDescriptor,
            [MarshalAs(UnmanagedType.Bool)] out bool bDaclPresent,
            ref IntPtr pDacl,
            [MarshalAs(UnmanagedType.Bool)] out bool bDaclDefaulted
            );
    
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetAclInformation(
            IntPtr pAcl,
            ref ACL_SIZE_INFORMATION pAclInformation,
            uint nAclInformationLength,
            ACL_INFORMATION_CLASS dwAclInformationClass
         );
    
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern int GetAce(
            IntPtr aclPtr,
            int aceIndex,
            out IntPtr acePtr
         );
    
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern int GetLengthSid(
            IntPtr pSID
         );
    
        [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ConvertSidToStringSid(
            [MarshalAs(UnmanagedType.LPArray)] byte[] pSID,
            out IntPtr ptrSid
         );
    
        [DllImport("netapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        static extern int NetApiBufferFree(
            IntPtr buffer
         );
    
        enum SID_NAME_USE
        {
            SidTypeUser = 1,
            SidTypeGroup,
            SidTypeDomain,
            SidTypeAlias,
            SidTypeWellKnownGroup,
            SidTypeDeletedAccount,
            SidTypeInvalid,
            SidTypeUnknown,
            SidTypeComputer
        }
    
        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool LookupAccountSid(
          string lpSystemName,
          [MarshalAs(UnmanagedType.LPArray)] byte[] Sid,
          System.Text.StringBuilder lpName,
          ref uint cchName,
          System.Text.StringBuilder ReferencedDomainName,
          ref uint cchReferencedDomainName,
          out SID_NAME_USE peUse);
    
        [StructLayout(LayoutKind.Sequential)]
        struct SHARE_INFO_502
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            public string shi502_netname;
            public uint shi502_type;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string shi502_remark;
            public Int32 shi502_permissions;
            public Int32 shi502_max_uses;
            public Int32 shi502_current_uses;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string shi502_path;
            public IntPtr shi502_passwd;
            public Int32 shi502_reserved;
            public IntPtr shi502_security_descriptor;
        }
    
        [StructLayout(LayoutKind.Sequential)]
        struct ACL_SIZE_INFORMATION
        {
            public uint AceCount;
            public uint AclBytesInUse;
            public uint AclBytesFree;
        }
    
        [StructLayout(LayoutKind.Sequential)]
        public struct ACE_HEADER
        {
            public byte AceType;
            public byte AceFlags;
            public short AceSize;
        }
    
        [StructLayout(LayoutKind.Sequential)]
        struct ACCESS_ALLOWED_ACE
        {
            public ACE_HEADER Header;
            public int Mask;
            public int SidStart;
        }
    
        enum ACL_INFORMATION_CLASS
        {
            AclRevisionInformation = 1,
            AclSizeInformation
        }
    
    
    
        static void Main(string[] args)
        {
            IntPtr bufptr = IntPtr.Zero;
            int err = NetShareGetInfo("ServerName", "ShareName", 502, out bufptr);
            if (0 == err)
            {
                SHARE_INFO_502 shareInfo = (SHARE_INFO_502)Marshal.PtrToStructure(bufptr, typeof(SHARE_INFO_502));
    
                bool bDaclPresent;
                bool bDaclDefaulted;
                IntPtr pAcl = IntPtr.Zero;
                GetSecurityDescriptorDacl(shareInfo.shi502_security_descriptor, out bDaclPresent, ref pAcl, out bDaclDefaulted);
                if (bDaclPresent)
                {
                    ACL_SIZE_INFORMATION AclSize = new ACL_SIZE_INFORMATION();
                    GetAclInformation(pAcl, ref AclSize, (uint)Marshal.SizeOf(typeof(ACL_SIZE_INFORMATION)), ACL_INFORMATION_CLASS.AclSizeInformation);
                    for (int i = 0; i < AclSize.AceCount; i++)
                    {
                        IntPtr pAce;
                        err = GetAce(pAcl, i, out pAce);
                        ACCESS_ALLOWED_ACE ace = (ACCESS_ALLOWED_ACE)Marshal.PtrToStructure(pAce, typeof(ACCESS_ALLOWED_ACE));
    
                        IntPtr iter = (IntPtr)((long)pAce + (long)Marshal.OffsetOf(typeof(ACCESS_ALLOWED_ACE), "SidStart"));
                        byte[] bSID = null;
                        int size = (int)GetLengthSid(iter);
                        bSID = new byte[size];
                        Marshal.Copy(iter, bSID, 0, size);
                        IntPtr ptrSid;
                        ConvertSidToStringSid(bSID, out ptrSid);
                        string strSID = Marshal.PtrToStringAuto(ptrSid);
    
                        Console.WriteLine("The details of ACE number {0} are: ", i+1);
    
                        StringBuilder name = new StringBuilder();
                        uint cchName = (uint)name.Capacity;
                        StringBuilder referencedDomainName = new StringBuilder();
                        uint cchReferencedDomainName = (uint)referencedDomainName.Capacity;
                        SID_NAME_USE sidUse;
    
                        LookupAccountSid(null, bSID, name, ref cchName, referencedDomainName, ref cchReferencedDomainName, out sidUse);
    
                        Console.WriteLine("Trustee Name: " + name);
                        Console.WriteLine("Domain Name: " + referencedDomainName);
    
                        if ((ace.Mask & 0x1F01FF) == 0x1F01FF)
                        {
                            Console.WriteLine("Permission: Full Control");
                        }
                        else if ((ace.Mask & 0x1301BF) == 0x1301BF)
                        {
                            Console.WriteLine("Permission: READ and CHANGE");
                        }
                        else if ((ace.Mask & 0x1200A9) == 0x1200A9)
                        {
                            Console.WriteLine("Permission: READ only");
                        }
                        Console.WriteLine("SID: {0} \nHeader AceType: {1} \nAccess Mask: {2} \nHeader AceFlag: {3}", strSID, ace.Header.AceType.ToString(), ace.Mask.ToString(), ace.Header.AceFlags.ToString());
                        Console.WriteLine("\n");
                    }
                }
                err = NetApiBufferFree(bufptr);
            }
        }
    }
