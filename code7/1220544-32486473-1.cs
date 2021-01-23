     // Sender.cs
     // shared functionality with narrow API, consider interface
     class Sender
     {
         public SendByte(byte byte);
     }
     // SenderExtensions.cs
     // extensions to send various types 
     static class SenderExtensions
     {
         public static SendShort(this Sender sender, uint value)
         {
            sender.SendByte(value & 0xff);
            sender.SendByte(value & 0xff00);
         }
     }
