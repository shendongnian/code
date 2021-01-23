        private static Guid Increment(Guid guid)
        {
            byte[] bytes = guid.ToByteArray();
            byte[] order = { 15, 14, 13, 12, 11, 10, 9, 8, 6, 7, 4, 5, 0, 1, 2, 3 };
            for (int i = 0; i < 16; i++)
            {
                if (bytes[order[i]] == byte.MaxValue)
                {
                    bytes[order[i]] = 0;
                }
                else
                {
                    bytes[order[i]]++;
                    return new Guid(bytes);
                }
            }
            throw new OverflowException("Congratulations you are one in a billion billion billion billion etc...");
        }
