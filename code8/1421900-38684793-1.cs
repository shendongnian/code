        public DateTimeOffset ReadDateTimeOffset()
        {
            var dateTime = ReadDateTime();
            var minutes = ReadInt16();
            return new DateTimeOffset(dateTime, TimeSpan.FromMinutes(minutes));
        }
