    class CksAdapterCallback
    {       
        private IntPtr instance;
        public CksAdapterCallback()
        {
            instance = Marshal.AllocHGlobal(IntPtr.Size * 6);
            IntPtr vtblPtr = IntPtr.Add(instance, IntPtr.Size);
            Marshal.WriteIntPtr(instance, vtblPtr);
            Marshal.WriteIntPtr(vtblPtr, IntPtr.Zero); //dummy entry for the destructor
            OnConnectedInternal = new OnConnectedDelegate(OnConnected);
            Marshal.WriteIntPtr(IntPtr.Add(vtblPtr, IntPtr.Size), Marshal.GetFunctionPointerForDelegate(OnConnectedInternal));
            OnDataInternal = new OnDataDelegate(OnData);
            Marshal.WriteIntPtr(IntPtr.Add(vtblPtr, 2*IntPtr.Size), Marshal.GetFunctionPointerForDelegate(OnDataInternal));
            ...
        }
        ~CksAdapterCallback()
        {
            Marshal.FreeHGlobal(instance);
        }
        public IntPtr Instance
        {
            get { return instance; }
        }
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        delegate void OnConnectedDelegate(IntPtr instance, Int32 clientID);
        OnConnectedDelegate OnConnectedInternal;
        void OnConnected(IntPtr instance, Int32 clientID)
        {
            ...
        }
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        delegate void OnDataDelegate(IntPtr instance, Int32 clientID, IntPtr data);
        OnDataDelegate OnDataInternal;
        void OnData(IntPtr instance, Int32 clientID, IntPtr data)
        {
            ...
        }
		...
    }
	
    class CksAdapterProxy
    {        
        private IntPtr instance;
        public CksAdapterProxy(IntPtr instance)
        {
            this.instance = instance;
            IntPtr vtblPtr = Marshal.ReadIntPtr(instance, 0);
            IntPtr funcPtr = Marshal.ReadIntPtr(vtblPtr, 1 * IntPtr.Size);            
            ReleaseInternal = Marshal.GetDelegateForFunctionPointer<ReleaseDelegate>(funcPtr);
            ...
        }
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        delegate Int32 ReleaseDelegate(IntPtr instance);
        ReleaseDelegate ReleaseInternal;
        
		...
        public Int32 Release()
        {
            return ReleaseInternal(instance);
        }
        
        ...
    }
	
    public class CksAdapterTest
    {   
        [DllImport("CKS\\CksAdapter.dll")]
        [return: MarshalAs(UnmanagedType.I4)]
        static extern int CA_CreateAdapter(IntPtr adapterCallback, out IntPtr adapter);
        CksAdapterProxy adapter = null;
        CksAdapterCallback adapterCallback = new CksAdapterCallback();
        
        public CksAdapterTest()
        {            
            IntPtr nativeAdapter = IntPtr.Zero;
            int result = CA_CreateAdapter(adapterCallback.Instance, out nativeAdapter);
            if(result == 0)
            {
                adapter = new CksAdapterProxy(nativeAdapter);
                ...
                
                adapter.Release();
            }
		}
	}
