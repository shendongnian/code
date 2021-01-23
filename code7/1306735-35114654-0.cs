                    //split message into iv and encrypted bytes
                    byte[] iv = new byte[16];
                    byte[] workingHash = new byte[rage.Length - 16];
                    //put first 16 bytes into iv
                    for (int i = 0; i < 16; i++)
                    {
                        iv[i] = rage[i];
                    }
                    for (int i = 0; i < rage.Length - 16; i++)
                    {
                        workingHash[i] = rage[i + 16];
                    }
