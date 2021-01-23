    static class GuidExtensions
    {
        public static Guid Increment(this Guid guid)
        {
            var bytes = guid.ToByteArray();
            int i = 16;
            bool carry = true;
            while (carry && i > 0)
            {
                i--;
                byte oldValue = bytes[i]++;
                carry = oldValue > bytes[i];
            }
            return new Guid(bytes);
        }
    }
