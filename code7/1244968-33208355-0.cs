                DateTime[] timein = { DateTime.Parse("1:00"), DateTime.Parse("3:00"), DateTime.Parse("5:00"), DateTime.Parse("7:00") };
                DateTime[] timeout = { DateTime.Parse("2:00"), DateTime.Parse("4:00"), DateTime.Parse("6:00"), DateTime.Parse("8:00") };
                TimeSpan totalTime = new TimeSpan();
                for (int i = 0; i < timein.Count(); i++)
                {
                    totalTime += timeout[i] - timein[i];
                }​
