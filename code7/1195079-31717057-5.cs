    public static byte[] IntToByteArrayUsingBigInteger(int value, int numberOfBytes)
        {
            var res = (new BigInteger(value)).ToByteArray().Reverse().ToArray();
            if (res.Length == numberOfBytes)
                return res;
            byte[] result = new byte[numberOfBytes];
            if (res.Length > numberOfBytes)
                Array.Copy(res, res.Length - numberOfBytes, result, 0, numberOfBytes);
            else
                Array.Copy(res, 0, result, numberOfBytes - res.Length, res.Length);
            return result;
        }
