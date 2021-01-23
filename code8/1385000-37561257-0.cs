    public class Foo : MonoBehaviour
    {
        #region Fields
        private readonly int iterations = 1000000;
        private readonly int threadNum = 1;
        private int iterationsCompleted = 0;
        #endregion
    
        void Start()
        {
            Multithread();
        }
    
        private void Multithread()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
    
            //Start new Thread so that while (iterationsCompleted < iterations) ; will not run in the main loop
            new Thread(() =>
              {
    
                  for (int i = 0; i < threadNum; i++)
                  {
                      Hash hash = new Hash();
                      new Thread(() =>
                      {
                          while (Interlocked.Increment(ref iterationsCompleted) < iterations)
                          {
                              hash.Get(0, 0, 0);
                          }
                          UnityEngine.Debug.Log("Finished thread");
                      }).Start();
                  }
                  while (iterationsCompleted < iterations) ;
                  stopWatch.Stop();
                  UnityEngine.Debug.Log(stopWatch.Elapsed.TotalMilliseconds);
    
              }).Start();
        }
    }
    
    public class Hash
    {
        #region Fields
        // FNV parameters can be found at http://www.isthe.com/chongo/tech/comp/fnv/#FNV-param
        private const uint _FNVPrime = 16777619;
        private const uint _FNVOffset = 2166136261;
        private const uint _FNVMask8 = (1 << 8) - 1;
        private const int FIXEDSIZE = 3;
        private readonly System.Object locker = new System.Object();
        #endregion
    
        #region Class Methods
        private static uint FNV1A(uint[] data)
        {
            uint hash = _FNVOffset;
    
            Buffer.BlockCopy(data, 0, byteArray, 0, byteArray.Length);
    
            for (int i = 0; i < byteArray.Length; i++)
            {
                hash = hash ^ byteArray[i];
                hash = hash * _FNVPrime;
            }
            return hash;
        }
    
        static byte[] byteArray = new byte[FIXEDSIZE * sizeof(UInt32)];
        static uint[] data = new uint[3] { (uint)0, (uint)0, 0 };
    
        public uint Get(int x, int y, uint seed)
        {
            lock (locker)
            {
                data[0] = (uint)x;
                data[1] = (uint)y;
                data[2] = (uint)seed;
                return FNV1A(data);
            }
        }
        #endregion
    }
