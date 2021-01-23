    public static byte[] IntToByteArrayUsingBigInteger(int value)
        {
            byte[] fourbytes = new byte[4];
            var res = (new BigInteger(value)).ToByteArray().Reverse().ToArray();
            Array.Copy(res, 0, fourbytes, 4 - res.Length, res.Length);
            return fourbytes;
        }
