        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        [Guid("D11AD862-66DE-4DF4-BF6C-1F5621996AF1")]
        public interface IOpenControlPanel
        {
            [PreserveSig]
            int Open([MarshalAs(UnmanagedType.LPWStr)] string name,
                     [MarshalAs(UnmanagedType.LPWStr)] string page,
                                                       IntPtr punkSite);
            [PreserveSig]
            int GetPath([MarshalAs(UnmanagedType.LPWStr)] string name,
                        [MarshalAs(UnmanagedType.LPWStr)] StringBuilder refPath,
                                                          int bufferSize);
            ControlPanelView GetCurrentView();
            // if you remove preservesig, you can return the [out] param directly
        }
