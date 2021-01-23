     DateTime endDate = new DateTime(DateTime.Today.Year + 1, 4, 1).AddDays(-1);
                if (Convert.ToDateTime(empHiredDate).Month >= 4)
                {
                    finMonth = Convert.ToDateTime(empHiredDate).Month - 3;
                    avail =Convert.ToString(finMonth * 1.25);
                }
                else if (Convert.ToDateTime(empHiredDate).Month <= 3)
                {
                    finMonth = Convert.ToDateTime(empHiredDate).Month + 9;
                    avail = Convert.ToString(finMonth * 1.25);
                }
