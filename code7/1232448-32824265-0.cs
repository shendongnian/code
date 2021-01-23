        public static DateTimeOffset Parse(string str)
        {
            string[] formats =
            {
                "dd/MM/yyyy HH.mm.ss zzz",
                "dd/MM/yyyy HH:mm:ss zzz"
                // ... possibly more ...
            };
            var dto = new DateTimeOffset();
            if (!formats.Any(f => DateTimeOffset.TryParseExact(str, f, CultureInfo.InvariantCulture, DateTimeStyles.None, out dto)))
            {
                throw new ArgumentException("Unrecognized date format");
            }
            return dto;
        }
