    [StructLayout(LayoutKind.Sequential)]
    public class In_Module //ported from IN2.H in the Winamp SDK, struct size 152
    {
        [DllImport("kernel32", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, EntryPoint = "LoadLibraryW", ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr LoadLibrary(string lpFileName);
        [DllImport("kernel32", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);
        private static readonly int OffsetOfMethodTable = sizeof(int) + IntPtr.Size + IntPtr.Size + IntPtr.Size + IntPtr.Size + sizeof(int) + sizeof(int);
        IntPtr Ptr;
        public void LoadMidiModule()
        {
            IntPtr hmod = LoadLibrary("in_midi.dll");
            if (hmod == IntPtr.Zero)
            {
                throw new Win32Exception();
            }
            IntPtr proc = GetProcAddress(hmod, "winampGetInModule2");
            if (proc == IntPtr.Zero)
            {
                throw new Win32Exception();
            }
            PluginGetter getmod = (PluginGetter)Marshal.GetDelegateForFunctionPointer(proc, typeof(PluginGetter));
            Ptr = getmod();
            if (Ptr == IntPtr.Zero)
            {
                throw new Exception();
            }
            hDllInstance = hmod;
            config = GetDelegate<ConfigFunc>(0 * IntPtr.Size);
            about = GetDelegate<AbountFunc>(1 * IntPtr.Size);
            init = GetDelegate<InitFunc>(2 * IntPtr.Size);
            quit = GetDelegate<QuitFunc>(3 * IntPtr.Size);
            getFileInfo = GetDelegate<GetFileInfoFunc>(4 * IntPtr.Size);
            infoBox = GetDelegate<InfoBoxFunc>(5 * IntPtr.Size);
            isOurFile = GetDelegate<IsOurFileFunc>(6 * IntPtr.Size);
            play = GetDelegate<PlayFunc>(7 * IntPtr.Size);
            pause = GetDelegate<PauseFunc>(8 * IntPtr.Size);
            unPause = GetDelegate<UnPauseFunc>(9 * IntPtr.Size);
            isPaused = GetDelegate<IsPausedFunc>(10 * IntPtr.Size);
            stop = GetDelegate<StopFunc>(11 * IntPtr.Size);
            getLength = GetDelegate<GetLengthFunc>(12 * IntPtr.Size);
            getOutputTime = GetDelegate<GetOutputTimeFunc>(13 * IntPtr.Size);
            setOutputTime = GetDelegate<SetOutputTimeFunc>(14 * IntPtr.Size);
            setVolume = GetDelegate<SetVolumeFunc>(15 * IntPtr.Size);
            setPan = GetDelegate<SetPanFunc>(16 * IntPtr.Size);
            savsaInit = GetDelegate<SAVSAInitFunc>(17 * IntPtr.Size);
            savsaDeInit = GetDelegate<SAVSADeInitFunc>(18 * IntPtr.Size);
            saAddPCMData = GetDelegate<SAAddPCMDataFunc>(19 * IntPtr.Size);
            saGetMode = GetDelegate<SAGetModeFunc>(20 * IntPtr.Size);
            saAdd = GetDelegate<SAAddFunc>(21 * IntPtr.Size);
            vsaAddPCMData = GetDelegate<VSAAddPCMDataFunc>(22 * IntPtr.Size);
            vsaGetMode = GetDelegate<VSAGetModeFunc>(23 * IntPtr.Size);
            vsaAdd = GetDelegate<VSAAddFunc>(24 * IntPtr.Size);
            vsaSetInfo = GetDelegate<VSASetInfoFunc>(25 * IntPtr.Size);
            dsp_isactive = GetDelegate<DSP_isactiveFunc>(26 * IntPtr.Size);
            dsp_dosamples = GetDelegate<DSP_dosamplesFunc>(27 * IntPtr.Size);
            eqSet = GetDelegate<EQSetFunc>(28 * IntPtr.Size);
            setInfo = GetDelegate<SetInfoFunc>(29 * IntPtr.Size);
        }
        private TDelegate GetDelegate<TDelegate>(int offset)
        {
            IntPtr ptr = Marshal.ReadIntPtr(Ptr, OffsetOfMethodTable + offset);
            if (ptr == IntPtr.Zero)
            {
                return default(TDelegate);
            }
            return (TDelegate)(object)Marshal.GetDelegateForFunctionPointer(ptr, typeof(TDelegate));
        }
        private void SetDelegate<TDelegate>(TDelegate del, ref TDelegate field, int offset)
        {
            field = del;
            IntPtr ptr = Marshal.GetFunctionPointerForDelegate((Delegate)(object)del);
            Marshal.WriteIntPtr(Ptr, OffsetOfMethodTable + offset, ptr);
        }
        public int version
        {
            get
            {
                return Marshal.ReadInt32(Ptr, 0);
            }
        }
        public string description
        {
            get
            {
                return Marshal.PtrToStringAnsi(Marshal.ReadIntPtr(Ptr, sizeof(int)));
            }
        }
        public IntPtr hMainWindow
        {
            get
            {
                return Marshal.ReadIntPtr(Ptr, sizeof(int) + IntPtr.Size);
            }
            set
            {
                Marshal.WriteIntPtr(Ptr, sizeof(int) + IntPtr.Size, value);
            }
        }
        public IntPtr hDllInstance
        {
            get
            {
                return Marshal.ReadIntPtr(Ptr, sizeof(int) + IntPtr.Size + IntPtr.Size);
            }
            set
            {
                Marshal.WriteIntPtr(Ptr, sizeof(int) + IntPtr.Size + IntPtr.Size, value);
            }
        }
        public string FileExtensions
        {
            get
            {
                return Marshal.PtrToStringAnsi(Marshal.ReadIntPtr(Ptr, sizeof(int) + IntPtr.Size + IntPtr.Size + IntPtr.Size));
            }
        }
        public int is_seekable
        {
            get
            {
                return Marshal.ReadInt32(Ptr, sizeof(int) + IntPtr.Size + IntPtr.Size + IntPtr.Size + IntPtr.Size);
            }
        }
        public int UsesOutputPlug
        {
            get
            {
                return Marshal.ReadInt32(Ptr, sizeof(int) + IntPtr.Size + IntPtr.Size + IntPtr.Size + IntPtr.Size + sizeof(int));
            }
        }
        private ConfigFunc config;
        public ConfigFunc Config
        {
            get
            {
                return config;
            }
        }
        private AbountFunc about;
        public AbountFunc About
        {
            get
            {
                return about;
            }
        }
        private InitFunc init;
        public InitFunc Init
        {
            get
            {
                return init;
            }
        }
        private QuitFunc quit;
        public QuitFunc Quit
        {
            get
            {
                return quit;
            }
        }
        private GetFileInfoFunc getFileInfo;
        public GetFileInfoFunc GetFileInfo
        {
            get
            {
                return getFileInfo;
            }
        }
        private InfoBoxFunc infoBox;
        public InfoBoxFunc InfoBox
        {
            get
            {
                return infoBox;
            }
        }
        private IsOurFileFunc isOurFile;
        public IsOurFileFunc IsOurFile
        {
            get
            {
                return isOurFile;
            }
        }
        private PlayFunc play;
        public PlayFunc Play
        {
            get
            {
                return play;
            }
        }
        private PauseFunc pause;
        public PauseFunc Pause
        {
            get
            {
                return pause;
            }
        }
        private UnPauseFunc unPause;
        public UnPauseFunc UnPause
        {
            get
            {
                return unPause;
            }
        }
        private IsPausedFunc isPaused;
        public IsPausedFunc IsPaused
        {
            get
            {
                return isPaused;
            }
        }
        private StopFunc stop;
        public StopFunc Stop
        {
            get
            {
                return stop;
            }
        }
        private GetLengthFunc getLength;
        public GetLengthFunc GetLength
        {
            get
            {
                return getLength;
            }
        }
        private GetOutputTimeFunc getOutputTime;
        public GetOutputTimeFunc GetOutputTime
        {
            get
            {
                return getOutputTime;
            }
        }
        private SetOutputTimeFunc setOutputTime;
        public SetOutputTimeFunc SetOutputTime
        {
            get
            {
                return setOutputTime;
            }
        }
        private SetVolumeFunc setVolume;
        public SetVolumeFunc SetVolume
        {
            get
            {
                return setVolume;
            }
        }
        private SetPanFunc setPan;
        public SetPanFunc SetPan
        {
            get
            {
                return setPan;
            }
        }
        private SAVSAInitFunc savsaInit;
        public SAVSAInitFunc SAVSAInit
        {
            get
            {
                return savsaInit;
            }
            set
            {
                SetDelegate(value, ref savsaInit, 17 * IntPtr.Size);
            }
        }
        private SAVSADeInitFunc savsaDeInit;
        public SAVSADeInitFunc SAVSADeInit
        {
            get
            {
                return savsaDeInit;
            }
            set
            {
                SetDelegate(value, ref savsaDeInit, 18 * IntPtr.Size);
            }
        }
        private SAAddPCMDataFunc saAddPCMData;
        public SAAddPCMDataFunc SAAddPCMData
        {
            get
            {
                return saAddPCMData;
            }
            set
            {
                SetDelegate(value, ref saAddPCMData, 19 * IntPtr.Size);
            }
        }
        private SAGetModeFunc saGetMode;
        public SAGetModeFunc SAGetMode
        {
            get
            {
                return saGetMode;
            }
            set
            {
                SetDelegate(value, ref saGetMode, 20 * IntPtr.Size);
            }
        }
        private SAAddFunc saAdd;
        public SAAddFunc SAAdd
        {
            get
            {
                return saAdd;
            }
            set
            {
                SetDelegate(value, ref saAdd, 21 * IntPtr.Size);
            }
        }
        private VSAAddPCMDataFunc vsaAddPCMData;
        public VSAAddPCMDataFunc VSAAddPCMData
        {
            get
            {
                return vsaAddPCMData;
            }
            set
            {
                SetDelegate(value, ref vsaAddPCMData, 22 * IntPtr.Size);
            }
        }
        private VSAGetModeFunc vsaGetMode;
        public VSAGetModeFunc VSAGetMode
        {
            get
            {
                return vsaGetMode;
            }
            set
            {
                SetDelegate(value, ref vsaGetMode, 23 * IntPtr.Size);
            }
        }
        private VSAAddFunc vsaAdd;
        public VSAAddFunc VSAAdd
        {
            get
            {
                return vsaAdd;
            }
            set
            {
                SetDelegate(value, ref vsaAdd, 24 * IntPtr.Size);
            }
        }
        private VSASetInfoFunc vsaSetInfo;
        public VSASetInfoFunc VSASetInfo
        {
            get
            {
                return vsaSetInfo;
            }
            set
            {
                SetDelegate(value, ref vsaSetInfo, 25 * IntPtr.Size);
            }
        }
        private DSP_isactiveFunc dsp_isactive;
        public DSP_isactiveFunc DSP_isactive
        {
            get
            {
                return dsp_isactive;
            }
            set
            {
                SetDelegate(value, ref dsp_isactive, 26 * IntPtr.Size);
            }
        }
        private DSP_dosamplesFunc dsp_dosamples;
        public DSP_dosamplesFunc DSP_dosamples
        {
            get
            {
                return dsp_dosamples;
            }
            set
            {
                SetDelegate(value, ref dsp_dosamples, 27 * IntPtr.Size);
            }
        }
        private EQSetFunc eqSet;
        public EQSetFunc EQSet
        {
            get
            {
                return eqSet;
            }
        }
        private SetInfoFunc setInfo;
        public SetInfoFunc SetInfo
        {
            get
            {
                return setInfo;
            }
            set
            {
                SetDelegate(value, ref setInfo, 29 * IntPtr.Size);
            }
        }
        public IntPtr OutMod
        {
            get
            {
                return Marshal.ReadIntPtr(Ptr, OffsetOfMethodTable + 30 * IntPtr.Size);
            }
        }
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate IntPtr PluginGetter();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ConfigFunc(IntPtr hwndParent);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void AbountFunc(IntPtr hwndParent);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void InitFunc();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void QuitFunc();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
        public delegate void GetFileInfoFunc(string file, string title, out int length_in_ms);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int InfoBoxFunc(string file, IntPtr hwndParent);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int IsOurFileFunc(string fn);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int PlayFunc(string fn);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void PauseFunc();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void UnPauseFunc();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int IsPausedFunc();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void StopFunc();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int GetLengthFunc();            // get length in ms
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int GetOutputTimeFunc();        // returns current output time in ms. (usually returns outMod->GetOutputTime()
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SetOutputTimeFunc(int time_in_ms); // seeks to point in stream (in ms). Usually you signal your thread to seek, which seeks and calls outMod->Flush()..
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SetVolumeFunc(int volume); // from 0 to 255.. usually just call outMod->SetVolume
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SetPanFunc(int pan);   // from -127 to 127.. usually just call outMod->SetPan
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SAVSAInitFunc(int maxlatency_in_ms, int srate);        // call once in Play(). maxlatency_in_ms should be the value returned from outMod->Open()
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SAVSADeInitFunc(); // call in Stop()
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SAAddPCMDataFunc(IntPtr PCMData, int nch, int bps, int timestamp);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int SAGetModeFunc();        // gets csa (the current type (4=ws,2=osc,1=spec))
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int SAAddFunc(IntPtr data, int timestamp, int csa); // sets the spec data, filled in by winamp
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void VSAAddPCMDataFunc(IntPtr PCMData, int nch, int bps, int timestamp); // sets the vis data directly from PCM data
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int VSAGetModeFunc(out int specNch, out int waveNch); // use to figure out what to give to VSAAdd
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int VSAAddFunc(IntPtr data, int timestamp); // filled in by winamp, called by plug-in
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void VSASetInfoFunc(int srate, int nch); // <-- Correct (benski, dec 2005).. old declaration had the params backwards
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int DSP_isactiveFunc();
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int DSP_dosamplesFunc(ref short samples, int numsamples, int bps, int nch, int srate);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void EQSetFunc(int on, byte[] data, int preamp); // 0-64 each, 31 is +0, 0 is +12, 63 is -12. Do nothing to ignore.
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SetInfoFunc(int bitrate, int srate, int stereo, int synched); // if -1, changes ignored? :)
    }
