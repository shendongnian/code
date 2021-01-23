       public class MprWrapper
        {
            [DllImport("Mpr.dll")]
            private static extern int WNetUseConnection(
                IntPtr hwndOwner,
                _NETRESOURCE lpNetResource,
                string lpPassword,
                string lpUserID,
                int dwFlags,
                string lpAccessName,
                string lpBufferSize,
                string lpResult
                );
    
            struct _NETRESOURCE
            {
                public int dwScope;
                public int dwType;
                public int dwDisplayType;
                public int dwUsage;
                public string lpLocalName;
                public string lpRemoteName;
                public string lpComment;
                public string lpProvider;
            }
    
    
            public static void WNetUseConnection(string remoteName, string user, string pass)
            {
                _NETRESOURCE myStruct = new _NETRESOURCE
                {
                    dwType = 1, //it's a disk (0 is any, 2 is printer)
                    lpRemoteName = remoteName
                };
    
                int error = WNetUseConnection(new IntPtr(0), myStruct, pass, user, 0, null, null, null);
                if (error != 0)
                {
                    throw new Exception("That didn't work either");
                }
                // if we reach here then everything worked!!!
            }
        }
