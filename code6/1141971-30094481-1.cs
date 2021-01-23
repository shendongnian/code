            int myInt = 100;
            byte[] byteArray = BitConverter.GetBytes(myInt);
            using (MemoryStream stream = new MemoryStream(byteArray)) {
                using (BinaryReader reader = new BinaryReader(stream)) {
                    var i = reader.ReadInt32();
                }
            }
