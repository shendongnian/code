        public DateTime GetGregorianDate(string persianDate)
        {
            PersianCalendar persian_date = new PersianCalendar();
            var dateParts = GetDateParts(persianDate);
            DateTime dt = persian_date.ToDateTime(dateParts[0], dateParts[1], dateParts[2], 0, 0, 0, 0, 0);
            return dt;
        }
        public int[] GetDateParts(string persianDate)
        {
            return persianDate.Split('/').Select(datePart => int.Parse(datePart)).ToArray();
        }
