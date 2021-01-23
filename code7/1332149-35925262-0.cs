    public enum MessageIdentifier : byte
            {
                LaserRange = 0x50,
            };
    
            // ...more code
    
            private static void ParseMessage(byte[] fullPacket)
            {
                switch ((MessageIdentifier)fullPacket[3])
                {
                    case MessageIdentifier.LaserRange:
                        ;// some wonderful code
                        break;
                }
            }
