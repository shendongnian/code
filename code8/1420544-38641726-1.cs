    public unsafe class MyClass
    {
        delegate void IDE_MenuState(int ID, int Index, bool Enabled);
        delegate bool IDE_Connected();
        delegate void IDE_GetConnectionInfo(char** Username, char** Password, char** Database);
        delegate void IDE_GetBrowserInfo(char** ObjectType, char** ObjectOwner, char** ObjectName);
        static IDE_MenuState method_IDE_MenuState;
        static IDE_Connected method_IDE_Connected;
        static IDE_GetConnectionInfo method_IDE_GetConnectionInfo;
        static IDE_GetBrowserInfo method_IDE_GetBrowserInfo;
        public static void RegisterCallback(int Index, IntPtr Addr)
        {
            switch (Index)
            {
                case 10:
                    method_IDE_MenuState = (IDE_MenuState)Marshal.GetDelegateForFunctionPointer(Addr, typeof(IDE_MenuState));
                    break;
                case 11:
                    method_IDE_Connected = (IDE_Connected)Marshal.GetDelegateForFunctionPointer(Addr, typeof(IDE_Connected));
                    break;
                case 12:
                    method_IDE_GetConnectionInfo = (IDE_GetConnectionInfo)Marshal.GetDelegateForFunctionPointer(Addr, typeof(IDE_GetConnectionInfo));
                    break;
                case 13:
                    method_IDE_GetBrowserInfo = (IDE_GetBrowserInfo)Marshal.GetDelegateForFunctionPointer(Addr, typeof(IDE_GetBrowserInfo));
                    break;
            }
        }
        public static void IDE_MenuState(int ID, int Index, bool Enabled)
        {
            if (method_IDE_MenuState == null)
            {
                throw new MissingMethodException("IDE_MenuState has not been assigned pointer yet.");
            }
            method_IDE_MenuState(ID, Index, Enabled);
        }
        public static bool IDE_Connected()
        {
            if (method_IDE_Connected == null)
            {
                throw new MissingMethodException("IDE_Connected has not been assigned pointer yet.");
            }
            return method_IDE_Connected();
        }
        public static void IDE_GetConnectionInfo(char** Username, char** Password, char** Database)
        {
            if (method_IDE_GetConnectionInfo == null)
            {
                throw new MissingMethodException("IDE_GetConnectionInfo has not been assigned pointer yet.");
            }
            method_IDE_GetConnectionInfo(Username, Password, Database);
        }
        public static void IDE_GetBrowserInfo(char** ObjectType, char** ObjectOwner, char** ObjectName)
        {
            if (method_IDE_GetBrowserInfo == null)
            {
                throw new MissingMethodException("IDE_GetBrowserInfo has not been assigned pointer yet.");
            }
            method_IDE_GetBrowserInfo(ObjectType, ObjectOwner, ObjectName);
        }
    }
