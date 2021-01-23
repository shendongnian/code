    public static List<ChartPoint> RenderWeeklyAverageChart(List<myclass> myclass, DateTime start, DateTime end)
            {
                DateTime datePointer = start; //1st date in list
                List<ChartPoint> points = new List<ChartPoint>();
                double average = 0;
    
                if (myclass!= null && myclass.Count > 0)
                {
                    while (datePointer < DateTime.Now)
                    {
                        //Filter By Selected Week
                        List<myclass> Weekmyclass = myclass.Where(c => c.RequestedTimestamp >= datePointer &&
                            c.RequestedTimestamp < datePointer.AddDays(7)).ToList();
                        //If there are records, find the average timespan of the records
                        if (Weekmyclass != null && Weekmyclass.Count > 0)
                        {
                            long ticks = (long)WeekSlabs.Average(c => (c.DeliveredTimestamp.Value - c.RequestedTimestamp.Value).Ticks);
                            average = TimeSpan.FromTicks(ticks).TotalHours;
    
                            points.Add(new ChartPoint
                            {
                                PointValue = average,
                                AxisXText = datePointer.ToShortDateString() + " - "
                                            + datePointer.AddDays(7).ToShortDateString()
                            });
                        }
                        else
                        {
                            //Otherwise Add a Zero Record
                            points.Add(new ChartPoint
                            {
                                PointValue = 0,
                                AxisXText = datePointer.ToShortDateString() + " - "
                                            + datePointer.AddDays(7).ToShortDateString()
                            });
                        }
                        datePointer = datePointer.AddDays(7);
                    }
                }
                return points;
            }
