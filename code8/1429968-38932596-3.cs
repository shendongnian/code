    using System;
    using System.Globalization;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication7
    {
        class Program
        {
            static void Main(string[] args)
            {
                byte[] input = {52, 0, 8, 0, 1, 12, 0, 0, 0, 0, 0, 0, 1, 67, 149, 240,
                                   109, 66, 194, 95, 17, 66, 78, 82, 48, 57, 66, 49, 55,
                                   53, 55, 50, 0, 0, 49, 54, 45, 48, 56, 45, 49, 51, 32, 48, 56, 58, 51, 48, 58, 52, 54, 0
                               };
                GPS gps = new GPS(input);
            }
        }
        public class GPS
        {
            UInt16 packetLen { get; set; }
            UInt16 cmd { get; set; }
            Boolean bEnable { get; set; }
            byte bAlarm { get; set; }
            uint nSpeed { get; set; }
            float nDirection { get; set; }
            float fLongitude { get; set; }
            float fLatitude { get; set; }
            byte[] sUserID { get; set; }
            string userID = "";
            byte[] bDateTime { get; set; }
            string sDateTime = "";
            DateTime dateTime { get; set; }
            public GPS(byte[] bytes)
            {
                packetLen = BitConverter.ToUInt16(bytes, 0);
                cmd = BitConverter.ToUInt16(bytes, 2);
                bEnable = BitConverter.ToBoolean(bytes, 4);
                bAlarm = bytes[5];
                nSpeed = BitConverter.ToUInt32(bytes, 6);
                nDirection = BitConverter.ToSingle(bytes.Skip(10).Take(4).ToArray(),0);
                fLongitude = BitConverter.ToSingle(bytes.Skip(14).Take(4).ToArray(),0);
                fLatitude = BitConverter.ToSingle(bytes.Skip(18).Take(4).ToArray(),0);
                sUserID = bytes.Skip(22).Take(12).ToArray();
                userID = Encoding.ASCII.GetString(sUserID).Replace("\0", "");
                bDateTime = bytes.Skip(34).ToArray();
                sDateTime = Encoding.ASCII.GetString(bDateTime).Replace("\0", "");
                dateTime = DateTime.ParseExact(sDateTime, "yy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            }
        }
    }
