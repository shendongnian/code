    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public unsafe struct Frame
    {
        public uint Flags;
        public uint TimeCode;
        public uint NodeMoving;
        public fixed Matrix nodeRots[NUM_GYROS];
        public Vector Position;
        public uint ContactPoints;
        public fixed float channel[CHANNEL_ARRAY_SIZE];
        public unsafe float[] Channel
        {
            get
            {
                fixed (float* ptr = channel)
                {
                    float[] array = new float[CHANNEL_ARRAY_SIZE];
                    Marshal.Copy((IntPtr)ptr, array, 0, CHANNEL_ARRAY_SIZE * sizeof(float));
                    return array;
                }
            }
        }
        public unsafe Matrix[] NodeRots
        {
            get
            {
                fixed (Matrix* ptr = nodeRots)
                {
                    Matrix[] array = new Matrix[NUM_GYROS];
                    for (int i = 0; i < array.Length; i++)
                    {
                        array[i] = ptr[i];
                    }
                    return array;
                }
            }
        }
    }
