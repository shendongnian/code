    byte[] obj = ObjectToByteArray(queryObject);
                List<byte> list = obj.ToList();
                list.RemoveRange(0, 27);
                list.RemoveAt(list.Count - 1);
                obj = list.ToArray<byte>();
