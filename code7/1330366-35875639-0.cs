    public JsonResult GetChartData(string _campus, string _semester, string _fy)
            {
                IEnumerable<MathAimsScaleScore> query = db.MathAimsScaleScores
                    .Where(m => m.Campus == _campus)
                    .Where(m => m.Semester == _semester)
                    .Where(m=>m.FY==_fy);
                
                var FyList = query.Select(m => Convert.ToDouble(m.ScaleScore));
                var FyArray = new int[5];
    
                for (int i = 0; i < 5; i++)
                {
                    FyArray[i] = Convert.ToInt32(Statistics.FiveNumberSummary(FyList)[i]);
                }
    
                Dictionary<int, int> list = new Dictionary<int, int>();
                list.Add(0,FyArray[0]);
                list.Add(1, FyArray[1]);
                list.Add(2, FyArray[2]);
                list.Add(3, FyArray[3]);
                list.Add(4, FyArray[4]);
                            
                return Json(list.ToList());
            }
