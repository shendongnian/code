    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public unsafe struct Frame
    {
        public uint Flags;
        public uint TimeCode;
        public uint NodeMoving;
        public fixed float nodeRots[NUM_GYROS * 9];
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
                fixed (float* ptr = nodeRots)
                {
                    Matrix[] array = new Matrix[NUM_GYROS];
                    for (int i = 0, y = 0; i < array.Length; i++, y += 9)
                    {
                        array[i].xx = ptr[y + 0];
                        array[i].xy = ptr[y + 1];
                        array[i].xz = ptr[y + 2];
                        array[i].yx = ptr[y + 3];
                        array[i].yy = ptr[y + 4];
                        array[i].yz = ptr[y + 5];
                        array[i].zx = ptr[y + 6];
                        array[i].zy = ptr[y + 7];
                        array[i].zz = ptr[y + 8];
                    }
                    return array;
                }
            }
        }
    }
