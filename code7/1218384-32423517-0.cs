    using System;
    namespace ConsoleWindowPos
    {
        struct GPSMessage
        {
            public byte ValidityFlags { get; set; }
            public Int32 TargetLatRaw { get; set; }
            public float TargetLat { get { return 90.0f / (Int32.MaxValue-1) * (float)TargetLatRaw ; } }
            public Int32 TargetLongRaw { get; set; }
            public float TargetLong { get { return 180.0f / (Int32.MaxValue-1) * (float)TargetLongRaw; } }
            public static GPSMessage FromBinary(byte[] payload)
            {
                System.IO.MemoryStream stream = new System.IO.MemoryStream(payload);
                System.IO.BinaryReader reader = new System.IO.BinaryReader(stream);
                GPSMessage result = new GPSMessage();
                result.ValidityFlags = reader.ReadByte();
                result.TargetLatRaw = System.Net.IPAddress.NetworkToHostOrder(reader.ReadInt32());
                result.TargetLongRaw = System.Net.IPAddress.NetworkToHostOrder(reader.ReadInt32());
                return result;
            }
            public override string ToString()
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.AppendLine("GPSMessage: {");
                sb.AppendFormat("    ValidityFlags = 0x{0:X2};", ValidityFlags);
                sb.AppendLine();
                sb.Append("    TargetLatRaw = ");
                sb.Append(TargetLatRaw);
                sb.AppendLine(";");
                sb.Append("    TargetLat = ");
                sb.Append(TargetLat);
                sb.AppendLine(";");
                sb.Append("    TargetLongRaw = ");
                sb.Append(TargetLongRaw);
                sb.AppendLine(";");
                sb.Append("    TargetLong = ");
                sb.Append(TargetLong);
                sb.AppendLine(";");
                sb.Append("}");
                return sb.ToString();
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                byte[] payload = { 1,204,99,37,86,103,105,241,16,0,107,0,16,242,151,0,0,190 };
                var message = GPSMessage.FromBinary(payload);
                System.Console.WriteLine(message.ToString());
                System.Console.ReadLine();
            }
        }
    }
