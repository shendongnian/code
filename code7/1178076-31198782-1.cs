    public JsonResult AgeGroup()
        {
            List<AgeClass> agc = new List<AgeClass>();
            DataContext da = new DataContext();
            string age1 = "", age2 = "", age3 = "", age4 = "", age5 = "";
            int Count1 = 0, Count2 = 0, Count3 = 0, Count4 = 0, Count5 = 0;
            foreach (Patient p in da.Patients)
            {
                int Age = Convert.ToInt32(p.Age);
                if ((Age >= 13) && (Age <= 18))
                {
                    age1 = "13 - 18";
                    Count1++;
                }
                if ((Age >= 19) && (Age <= 30))
                {
                    age2 = "19 - 30";
                    Count2++;
                }
                if ((Age >= 31) && (Age <= 45))
                {
                    age3 = "31 - 45";
                    Count3++;
                }
                if ((Age >= 46) && (Age <= 60))
                {
                    age4 = "46 - 60";
                    Count4++;
                }
                if (Age >= 61)
                {
                    age5 = "61 Above";
                    Count5++;
                }
            }
