        public static void Run()
        {
            var i = new Image
            {
                ImageTime = DateTime.UtcNow,
                pData = Guid.NewGuid().ToByteArray()
            };
            var e = new Event
            {
                Name = Guid.NewGuid().ToString(),
                EventTime = DateTime.UtcNow,
                EventImages = new List<Image> {i}
            };
            var bytes = ObjectToByteArray(e);
            var e2 = ObjectFromByteArray(bytes);
            Console.WriteLine(e.Equals(e2));
        }
        public static byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
            {
                return null;
            }
            var bF = new BinaryFormatter();
            using (var mS = new MemoryStream())
            {
                bF.Serialize(mS, obj);
                return mS.ToArray();
            }
        }
        public static object ObjectFromByteArray(byte[] bytes)
        {
            if (bytes == null)
            {
                return null;
            }
            var bF = new BinaryFormatter();
            using (var mS = new MemoryStream(bytes))
            {
                return bF.Deserialize(mS);
            }
        }
