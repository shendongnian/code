			var data = new ByteBlock[2*3*4*3*4];
            var counter = 0;
            var bytes = new ByteBlock();
            for (byte a = 0; a < 2; a++)
            {
                bytes.A = a;
                for (byte b = 0; b < 3; b++)
                {
                    bytes.B = b;
                    for (byte c = 0; c < 4; c++)
                    {
                        bytes.C = c;
                        for (byte d = 0; d < 3; d++)
                        {
                            bytes.D = d;
                            for (byte e = 0; e < 4; e++)
                            {
								bytes.E = e;
								data[counter++] = bytes;
                            }
                        }
                    }
                }
            }
