    public static byte[] IntToByteArrayUsingBigInteger(int value, int numberOfBytes)
        {
            byte[] fourbytes = new byte[numberOfBytes];
            var res = (new BigInteger(value)).ToByteArray().Reverse().ToArray();
            Array.Copy(res, 0, fourbytes, numberOfBytes - res.Length, res.Length);
            return fourbytes;
        }
