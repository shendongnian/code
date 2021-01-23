    public class MyDevice
    {
        private const int PayloadIdByte = 0;
        private const int PayloadSliderId = 3;
        private const int PayloadButtonId = 4;
        private const int Button1Byte = 1;
        private const int Button2Byte = 2;
        private const int Button3Byte = 3;
        private const int Slider1Byte = 4;
        private const int Slider2Byte = 3;
        private const int PayloadSize = 8;
    
        public bool Button1 { get; set; }
        public bool Button2 { get; set; }
        public bool Button3 { get; set; }
        public byte Slider1 { get; set; }
        public byte Slider2 { get; set; }
    
        public MyDevice()
        {
    
        }
    
        public void Update(byte[] payload)
        {
            if (payload.Length != PayloadSize)
                throw new ArgumentException("payload");
    
            if (payload[PayloadIdByte] == PayloadSliderId)
            {
                Slider1 = payload[Slider1Byte];
                Slider2 = payload[Slider2Byte];
            }
    
            if (payload[PayloadIdByte] == PayloadButtonId)
            {
                Button1 = payload[Button1Byte] > 0;
                Button2 = payload[Button2Byte] > 0;
                Button3 = payload[Button3Byte] > 0;
            }
        }
    }
