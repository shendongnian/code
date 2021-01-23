        private static bool ZeroDetectSseInner(this byte[] arrayToOr, int l, int r)
        {
            var orVector   = new Vector<byte>(0);
            var ZeroVector = new Vector<byte>(0);
            int sseIndexEnd = l + ((r - l + 1) / Vector<byte>.Count) * Vector<byte>.Count;
            int i;
            for (i = l; i < sseIndexEnd; i += Vector<byte>.Count)
            {
                var inVector = new Vector<byte>(arrayToOr, i);
                orVector |= inVector;
                if (orVector != ZeroVector)
                    return false;
            }
            byte overallOr = 0;
            for (; i <= r; i++)
                overallOr |= arrayToOr[i];
            for (i = 0; i < Vector<byte>.Count; i++)
                overallOr |= orVector[i];
            return overallOr == 0;
        }
        public static bool ZeroValueDetectSse(this byte[] arrayToDetect)
        {
            return arrayToDetect.ZeroDetectSseInner(0, arrayToDetect.Length - 1);
        }
