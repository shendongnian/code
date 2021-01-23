                Style s = (Style)this.Resources["cdbKey"];
                /* Loop through the Dates retrieved from DataBase*/
                  DateTime holidayDate = DateTime.Parse("10/02/2015");
                  DataTrigger dataTrigger = new DataTrigger() { Binding = new Binding("Date"), Value = holidayDate };
                  dataTrigger.Setters.Add(new Setter(CalendarDayButton.BackgroundProperty, Brushes.SandyBrown));
                  s.Triggers.Add(dataTrigger);
                /*End Loop*/
