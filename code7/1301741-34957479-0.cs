        static byte[] ReinterpretAsByteArray(UInt32[] a)
        {
            using (MemoryStream s = new MemoryStream())
            {
                using (BinaryWriter w = new BinaryWriter(s, Encoding.Unicode, true))
                {
                    for (int i = 0; i < a.Length; i++)
                    {
                        w.Write(a[i]);
                    }
                }
                return s.ToArray();
            }
        }
        static float[] ReinterpretAsFloatArray(byte[] b) {
            using (MemoryStream s = new MemoryStream(b, false)) {
                using (BinaryReader r = new BinaryReader(s, Encoding.Unicode, true))
                {
                    float[] f = new float[b.Length / 4]; // 4 = sizeof float
                    for (int i = 0; i < b.Length; i++)
                    {
                        f[i] = r.ReadSingle();
                    }
                    return f;
                }
            }
        }    
