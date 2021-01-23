    private static Guid Increment(Guid guid)
        {
            byte[] bytes = guid.ToByteArray();
            for (int i = 15; i >= 0; i--)
            {
                if (bytes[i] == byte.MaxValue)
                {
                    bytes[i] = 0;
                }
                else
                {
                    bytes[i]++;
                    return new Guid(bytes);
                }
            }
            throw new OverflowException("Congratulations you are one in a billion billion billion billion etc...");
        }
