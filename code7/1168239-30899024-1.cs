    public class VolumeEnumerator : IEnumerable<Volume>
    {
        public IEnumerator<Volume> GetEnumerator()
        {
            StringBuilder sb = new StringBuilder(2048);
            IntPtr volumeHandle = FindFirstVolume(sb, (uint)sb.MaxCapacity);
            {
                if (volumeHandle == IntPtr.Zero)
                    yield break;
                else
                {
                    do
                    {
                        yield return new Volume(sb.ToString());
                        sb.Clear();
                    }
                    while (FindNextVolume(volumeHandle, sb, (uint)sb.MaxCapacity));
                    FindVolumeClose(volumeHandle);
                }
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr FindFirstVolume([Out] StringBuilder lpszVolumeName,
           uint cchBufferLength);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool FindNextVolume(IntPtr hFindVolume, [Out] StringBuilder lpszVolumeName, uint cchBufferLength);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool FindVolumeClose(IntPtr hFindVolume);
    }
