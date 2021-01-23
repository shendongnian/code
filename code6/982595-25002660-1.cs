    public sealed class CycleTime
    {
        private Boolean m_trackingThreadTime;
        private SafeWaitHandle m_handle;
        private UInt64 m_startCycleTime;
        private CycleTime(Boolean trackingThreadTime, SafeWaitHandle handle)
        {
            m_trackingThreadTime = trackingThreadTime;
            m_handle = handle;
            m_startCycleTime = m_trackingThreadTime ? Thread() : Process(m_handle);
        }
        [CLSCompliant(false)]
        public UInt64 Elapsed()
        {
            UInt64 now = m_trackingThreadTime ? Thread(/*m_handle*/) : Process(m_handle);
            return now - m_startCycleTime;
        }
        public static CycleTime StartThread(SafeWaitHandle threadHandle)
        {
            return new CycleTime(true, threadHandle);
        }
        public static CycleTime StartProcess(SafeWaitHandle processHandle)
        {
            return new CycleTime(false, processHandle);
        }
        public static UInt64 Thread(IntPtr threadHandle)
        {
            UInt64 cycleTime;
            if (!QueryThreadCycleTime(threadHandle, out cycleTime))
                throw new Win32Exception();
            return cycleTime;
        }
        /// <summary>
        /// Retrieves the cycle time for the specified thread.
        /// </summary>
        /// <param name="threadHandle">Identifies the thread whose cycle time you'd like to obtain.</param>
        /// <returns>The thread's cycle time.</returns>
        [CLSCompliant(false)]
        public static UInt64 Thread(SafeWaitHandle threadHandle)
        {
            UInt64 cycleTime;
            if (!QueryThreadCycleTime(threadHandle, out cycleTime))
                throw new Win32Exception();
            return cycleTime;
        }
        [CLSCompliant(false)]
        public static UInt64 Thread()
        {
            UInt64 cycleTime;
            if (!QueryThreadCycleTime((IntPtr)(-2), out cycleTime))
                throw new Win32Exception();
            return cycleTime;
        }
        /// <summary>
        /// Retrieves the sum of the cycle time of all threads of the specified process.
        /// </summary>
        /// <param name="processHandle">Identifies the process whose threads' cycles times you'd like to obtain.</param>
        /// <returns>The process' cycle time.</returns>
        [CLSCompliant(false)]
        public static UInt64 Process(SafeWaitHandle processHandle)
        {
            UInt64 cycleTime;
            if (!QueryProcessCycleTime(processHandle, out cycleTime))
                throw new Win32Exception();
            return cycleTime;
        }
        /// <summary>
        /// Retrieves the cycle time for the idle thread of each processor in the system.
        /// </summary>
        /// <returns>The number of CPU clock cycles used by each idle thread.</returns>
        [CLSCompliant(false)]
        public static UInt64[] IdleProcessors()
        {
            Int32 byteCount = Environment.ProcessorCount;
            UInt64[] cycleTimes = new UInt64[byteCount];
            byteCount *= 8;   // Size of UInt64
            if (!QueryIdleProcessorCycleTime(ref byteCount, cycleTimes))
                throw new Win32Exception();
            return cycleTimes;
        }
        [DllImport("Kernel32", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern Boolean QueryThreadCycleTime(IntPtr threadHandle, out UInt64 CycleTime);
        [DllImport("Kernel32", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern Boolean QueryThreadCycleTime(SafeWaitHandle threadHandle, out UInt64 CycleTime);
        [DllImport("Kernel32", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern Boolean QueryProcessCycleTime(SafeWaitHandle processHandle, out UInt64 CycleTime);
        [DllImport("Kernel32", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern Boolean QueryIdleProcessorCycleTime(ref Int32 byteCount, UInt64[] CycleTimes);
        [DllImport("Kernel32", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetCurrentThread();
    }
    public sealed class CodeTimer //: IDisposable
    {
        private Int32 m_collectionCount0;
        private Int32 m_collectionCount1;
        private Int32 m_collectionCount2;
        private Thread m_thread;
        private IModel m_model;
        private Action<IModel> m_performanceMethod;
        private UInt64 outThreadCycles;
        public CodeTimer(Action<IModel> perfMethod, IModel model)
        {
            PrepareForOperation();
            m_performanceMethod = perfMethod;
            m_model = model;
            m_thread = new Thread(PerformanceTest);
        }
        private void PerformanceTest()
        {
            PrepareForOperation();
            IntPtr p = CycleTime.GetCurrentThread();
            UInt64 t = CycleTime.Thread(p);
            m_performanceMethod(m_model);
            outThreadCycles = CycleTime.Thread(p) - t;
        }
        public PerformanceStatus Time()
        {
            m_thread.Start();
            m_thread.Join();
            return new PerformanceStatus(GC.CollectionCount(0) - m_collectionCount0, GC.CollectionCount(1) - m_collectionCount1, GC.CollectionCount(2) - m_collectionCount2, outThreadCycles);
        }
        private void PrepareForOperation()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            m_collectionCount0 = GC.CollectionCount(0);
            m_collectionCount1 = GC.CollectionCount(1);
            m_collectionCount2 = GC.CollectionCount(2);
        }
    }
    public class PerformanceStatus
    {
        public Int32 GCCount1;
        public Int32 GCCount2;
        public Int32 GCCount3;
        public UInt64 CPUCycles;
        public PerformanceStatus(Int32 gc1, Int32 gc2, Int32 gc3, UInt64 cpuCycles)
        {
            this.GCCount1 = gc1;
            this.GCCount2 = gc2;
            this.GCCount3 = gc3;
            this.CPUCycles = cpuCycles;
        }
    }
