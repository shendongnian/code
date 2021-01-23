        public ExecutableLaunchOptions(
            SerializationInfo info, StreamingContext context) : this()
        {
            // Get the value of the window style from the serialization information.
            var enumerator = info.GetEnumerator();
            while (enumerator.MoveNext())
            {
                var current = enumerator.Current;
                if (current.Name == "windowStyle" && current.ObjectType == typeof(ProcessWindowStyle))
                {
                    this.windowStyle = (ProcessWindowStyle)current.Value;
                }
            }
        }
