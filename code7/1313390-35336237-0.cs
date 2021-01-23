                public static byte[] DeriveKey(byte[] key, int keySize, string primaryPurpose, params string[] specificPurposes)
                {
                    var secureUtf8Encoding = new UTF8Encoding(false, true);
                    var hash = new HMACSHA512(key);
                
                    using (hash)
                    {
                        var label = secureUtf8Encoding.GetBytes(primaryPurpose);
                
                        byte[] context;
                
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var binaryWriter = new BinaryWriter(memoryStream, secureUtf8Encoding))
                            {
                                foreach (var str in specificPurposes)
                                    binaryWriter.Write(str);
                                context = memoryStream.ToArray();
                            }
                        }
                
                        return DeriveKeyImpl(hash, label, context, keySize);
                    }
                }
                
                public static byte[] DeriveKeyImpl(HMAC hmac, byte[] label, byte[] context, int keyLengthInBits)
                {
                    int count1 = label != null ? label.Length : 0;
                    int count2 = context != null ? context.Length : 0;
                    byte[] buffer = new byte[checked(4 + count1 + 1 + count2 + 4)];
                    if (count1 != 0)
                        Buffer.BlockCopy((Array)label, 0, (Array)buffer, 4, count1);
                    if (count2 != 0)
                        Buffer.BlockCopy((Array)context, 0, (Array)buffer, checked(5 + count1), count2);
                    WriteUInt32ToByteArrayBigEndian(checked((uint)keyLengthInBits), buffer, checked(5 + count1 + count2));
                    int dstOffset = 0;
                    int val1 = keyLengthInBits / 8;
                    byte[] numArray = new byte[val1];
                    uint num = 1;
                    while (val1 > 0)
                    {
                        WriteUInt32ToByteArrayBigEndian(num, buffer, 0);
                        byte[] hash = hmac.ComputeHash(buffer);
                        int count3 = Math.Min(val1, hash.Length);
                        Buffer.BlockCopy((Array)hash, 0, (Array)numArray, dstOffset, count3);
                        checked { dstOffset += count3; }
                        checked { val1 -= count3; }
                        checked { ++num; }
                    }
                    return numArray;
                }
