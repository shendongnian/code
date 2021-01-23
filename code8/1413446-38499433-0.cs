     public enum Days
            {
                Mon = 1,
                Tue,
                Wed,
                Thur,
                Fri,
                Sat,
                Sun
            }
    public static IEnumerable<IEnumerable<int>> GroupDay(IEnumerable<int> ListOfDays)        
    {
                List<List<int>> Response = new List<List<int>>();
                List<int> Queue = new List<int>();
                var ListToIterate = ListOfDays.Distinct().OrderBy(d => d).ToList();
                foreach (var item in ListToIterate)
                {
    
                    if (Queue.Count == 0)
                    {
                        Queue.Add(item);
                    }
                    else
                    {
                        if ((item - 1) == Queue[Queue.Count - 1])
                        {
                            Queue.Add(item);
                        }
                        else if (item != (int)Days.Sun)
                        {
                            Response.Add(Queue);
                            Queue = new List<int>() { item };
                        }
                    }
    
                    if (item == ListToIterate.LastOrDefault())
                        Response.Add(Queue);
    
                    //Handle Sunday
                    if (item == (int)Days.Sun)
                    {
                        //Check if Saturday exists, if exists then do not put sunday before Monday.
                        var FindSaturday = Response.Where(r => r.Contains((int)Days.Sat)).FirstOrDefault();
                        if (FindSaturday == null)
                        {
                            var FindMonday = Response.Where(r => r.Contains((int)Days.Mon)).FirstOrDefault();
                            if (FindMonday != null)
                            {
                                FindMonday.Insert(0, item);
                            }
                        }
    
                    }
    
                }
                return Response;
            }
