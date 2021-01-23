            List<DateTime> passedDateList = new List<DateTime>();
            string OldDate = (day + "/" + month + "/" + year);
            DateTime dt1 = DateTime.Parse(OldDate);
            if (passedDateList.Contains(dt1))
            {
                // the date is already passed
            }
            else
            {
                // it is no yet passed 
                //Do your task here
                passedDateList.Add(dt1);
            }
