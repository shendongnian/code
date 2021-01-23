        public static bool Deserialize<T>(this String str, out T item)
        {
            var returnResult = default(T);
            var success = Ui.Instance.Try(
                () =>
                {
                    var ser = new XmlSerializer(typeof(T));
                    using (var reader = XmlReader.Create(new StringReader(str)))
                    {
                        returnResult = (T)ser.Deserialize(reader);
                    }
                },
                "Deserializing xml " + typeof(T),
                "Deserializing xml done",
                "Deserializing xml failed"
            );
            item = returnResult;
            return success;
        }
