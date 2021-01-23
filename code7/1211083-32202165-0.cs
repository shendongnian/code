    private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
        
        
            // Calculate the volume that's being set
            double newVolume = ushort.MaxValue * trackBar1.Value/ 10.0;
            uint v = ((uint) newVolume) & 0xffff;
            uint vAll = v | (v << 16);
            // Set the volume
            int retVal = NativeMethods.WaveOutSetVolume(IntPtr.Zero, vAll);
           
            bool playRetVal = NativeMethods.PlaySound("tada.wav", IntPtr.Zero, 0x2001);
           
        }
    }
    static class NativeMethods
    {
        [DllImport("winmm.dll", EntryPoint = "waveOutSetVolume")]
        public static extern int WaveOutSetVolume(IntPtr hwo, uint dwVolume);
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern bool PlaySound(string pszSound, IntPtr hmod, uint fdwSound);
    }
 
