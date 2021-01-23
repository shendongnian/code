    private byte[] Combine(byte[] a, byte[] b)
            {
                byte[] c = new byte[a.Length + b.Length];
                System.Buffer.BlockCopy(a, 0, c, 0, a.Length);
                System.Buffer.BlockCopy(b, 0, c, a.Length, b.Length);
                return c;
            }
