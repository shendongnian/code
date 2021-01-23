    namespace Project.DateTimeExtensions
    {
        public static class DateTimeExtensions
        {
            public static DateTime? FromVb6DateTime(this DateTime? dateTime)
            {
                // Is the DateTime a VB6 null representation, if so, return null
                return (dateTime.ToString("dd/MM/yyyy") == "11/11/1911") ? dateTime : null;
            }
        }
    }
