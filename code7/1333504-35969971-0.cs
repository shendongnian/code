        private string FncFormatDate(string date)
        {
            DateTime formattedDate;
            if (DateTime.TryParse(date, out formattedDate))
            {
                return formattedDate.ToString("yyyy-MM-dd");
            }
            else
            {
                return "Invalid date";
            }
        }
