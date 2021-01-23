        public override bool Row_Inserting(OrderedDictionary rsold, ref OrderedDictionary rsnew)
        {
            int Total_Pay;
            DateTime FROM_DATE = DateTime.Parse("02-May-2016"); //Replace with date you need
            DateTime TO_DATE = DateTime.Parse("08-May-2016"); //Replace with date you need
            Total_Pay = GetMonths(FROM_DATE, TO_DATE);
            return true;
        }
        public int GetMonths(DateTime FROM_DATE, DateTime TO_DATE)
        {
            if (FROM_DATE > TO_DATE)
            {
                throw new Exception("Start Date is greater than the End Date");
            }
            int months = ((TO_DATE.Year * 12) + TO_DATE.Month) - ((FROM_DATE.Year * 12) + FROM_DATE.Month);
            if (TO_DATE.Day >= FROM_DATE.Day)
            {
                months++;
            }
            return months;
        }
