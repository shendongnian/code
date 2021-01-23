        public static bool Deserialize<T>(this String str, out T item)
        {
            item = default(T);
            bool success;
            try
            {
                var ser = new XmlSerializer(typeof(T));
                using (var reader = XmlReader.Create(new StringReader(str)))
                {
                    item = (T)ser.Deserialize(reader);
                }
                success = true;
            }
            catch (Exception)
            {
                success = false;
            }
          
            return success;
        }
