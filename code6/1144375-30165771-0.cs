    public class BitConverterEx
    {
        public bool ProcessorLittleEndian { get; protected set; }
        public bool DataLittleEndian { get; protected set; }
        public BitConverterEx(bool dataLittleEndian)
        {
            ProcessorLittleEndian = BitConverter.IsLittleEndian;
            DataLittleEndian = dataLittleEndian;
        }
        public byte[] GetBytes(int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            if (DataLittleEndian != ProcessorLittleEndian)
            {
                Array.Reverse(bytes);
            }
            return bytes;
        }
        public int ToInt32(byte[] value, int startIndex)
        {
            if (DataLittleEndian == ProcessorLittleEndian)
            {
                return BitConverter.ToInt32(value, startIndex);
            }
            byte[] value2 = new byte[sizeof(int)];
            Array.Copy(value, startIndex, value2, 0, value2.Length);
            Array.Reverse(value2);
            return BitConverter.ToInt32(value2, 0);
        }
    }
    public class ManipulableBitConverterEx : BitConverterEx
    {
        public ManipulableBitConverterEx(bool processorLittleEndian, bool dataLittleEndian)
            : base(dataLittleEndian)
        {
            ProcessorLittleEndian = processorLittleEndian;
        }
    }
