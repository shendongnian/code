        // Definition of the IMessageFilter interface which we need to implement and 
        // register with the CoRegisterMessageFilter API.
        [ComImport(), Guid("00000016-0000-0000-C000-000000000046"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
        interface IOleMessageFilter // Renamed to avoid confusion w/ System.Windows.Forms.IMessageFilter
        {
            [PreserveSig]
            int HandleInComingCall(int dwCallType, IntPtr hTaskCaller, int dwTickCount, IntPtr lpInterfaceInfo);
            [PreserveSig]
            int RetryRejectedCall(IntPtr hTaskCallee, int dwTickCount, int dwRejectType);
            [PreserveSig]
            int MessagePending(IntPtr hTaskCallee, int dwTickCount, int dwPendingType);
        }
        internal sealed class OleMessageFilter : IOleMessageFilter, IDisposable
        {
            [DllImport("ole32.dll")]
            private static extern int CoRegisterMessageFilter(IOleMessageFilter newFilter, out IOleMessageFilter oldFilter);
            private bool _isRegistered;
            private IOleMessageFilter _oldFilter;
            public OleMessageFilter()
            {
                Register();
            }
            private void Register()
            {
                // CoRegisterMessageFilter is only supported on an STA thread.  This will throw an exception
                // if we can't switch to STA
                Thread.CurrentThread.SetApartmentState(ApartmentState.STA);
                int result = CoRegisterMessageFilter(this, out _oldFilter);
                if (result != 0)
                {
                    throw new COMException("CoRegisterMessageFilter failed", result);
                }
                _isRegistered = true;
            }
            private void Revoke()
            {
                if (_isRegistered)
                {
                    IOleMessageFilter revokedFilter;
                    CoRegisterMessageFilter(_oldFilter, out revokedFilter);
                    _oldFilter = null;
                    _isRegistered = false;
                }
            }
            #region IDisposable Members
            private void Dispose(bool disposing)
            {
                if (disposing)
                {
                    // Dispose managed resources
                }
                // Dispose unmanaged resources
                Revoke();
            }
            void IDisposable.Dispose()
            {
                GC.SuppressFinalize(this);
                Dispose(true);
            }
            ~OleMessageFilter()
            {
                Dispose(false);
            }
            #endregion
            #region IOleMessageFilter Members
            int IOleMessageFilter.HandleInComingCall(int dwCallType, IntPtr hTaskCaller, int dwTickCount, IntPtr lpInterfaceInfo)
            {
                return 0; //SERVERCALL_ISHANDLED
            }
            int IOleMessageFilter.RetryRejectedCall(IntPtr hTaskCallee, int dwTickCount, int dwRejectType)
            {
                if (dwRejectType == 2) // SERVERCALL_RETRYLATER
                {
                    return 200; // wait 200ms and try again
                }
                return -1; // cancel call
            }
            int IOleMessageFilter.MessagePending(IntPtr hTaskCallee, int dwTickCount, int dwPendingType)
            {
                return 2; //PENDINGMSG_WAITDEFPROCESS
            }
            #endregion
        }
