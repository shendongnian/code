    class Player
    {
        [DllImport("winmm.dll")]
        private static extern uint waveOutGetNumDevs();
        public uint GetNumDevs
        {
            get
            {
                return waveOutGetNumDevs();
            }
        }
    }
