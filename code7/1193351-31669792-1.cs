    public class BinaryEncodableInteger : IBinary<int>
    {
        // must have this if defined in interface,
        // but if defined as extension method you get it for free
        public byte[] Encode()
        {
            // serialization logic here
        }
    }
