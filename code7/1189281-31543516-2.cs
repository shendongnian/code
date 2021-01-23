    public class Command
    {
        public string DisplayText { get; set; }
        public string CommandText { get; set; }
        public Send(SerialPort serialPort)
        {
            if (serialPort.IsOpen) {
                var content = new List<byte>();
                content.Add(2);
                content.AddRange(Encoding.ASCII.GetBytes(CommandText));
                content.Add(3);
                byte[] buffer = content.ToArray();
                serialPort.Write(buffer, 0, buffer.Length);
            }
        }
        public override string ToString()
        {
            return DisplayText;
        }
    }
