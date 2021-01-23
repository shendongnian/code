            var born = new DateTime(1900, 02, 01);
            var checkdate = DateTime.Now;
            var nextBirthday = new DateTime(DateTime.Now.Year, born.Month, born.Day);
            if (nextBirthday < DateTime.Now)
            {
                nextBirthday = new DateTime(DateTime.Now.Year + 1, born.Month, born.Day);
            }
            if (checkdate.AddMonths(6) < nextBirthday)
            {
                Console.WriteLine("date is 6 months later then birthday");
            }
            else
            {
                Console.WriteLine("wait for it");
            }
