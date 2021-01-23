        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ATSessionStatusChangeCallback(ulong hSession, byte statusTyp);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ATLoginResponseCallback(ulong hSession, ulong hRequest, ref ATLOGINRESPONSE response);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ATRequestTimeoutCallback(ulong origRequest);
