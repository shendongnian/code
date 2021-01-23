    // Called from JsonResult (and other functions in the controller).
    public int[] GetFiveNumberSummary(string _campus, string _semester, string _fy)
            {
                IEnumerable<MathAimsScaleScore> query = db.MathAimsScaleScores
                    .Where(m => m.Campus == _campus)
                    .Where(m => m.Semester == _semester)
                    .Where(m => m.FY == _fy);
    
                var FyList = query.Select(m => Convert.ToDouble(m.ScaleScore)).ToList();
    
                var reply = new int[5];
                for (int i = 0; i < 5; i++)
                {
                    reply[i] = Convert.ToInt32(Statistics.FiveNumberSummary(FyList)[i]);
                }
                return reply;       
            }
    
            public JsonResult GetChartData(string _campus, string _semester)
            {           
                
                var FyArray0 =  GetFiveNumberSummary(_campus,_semester,"FY12").ToArray();
                var FyArray1 = GetFiveNumberSummary(_campus, _semester, "FY13").ToArray();
                var FyArray2 = GetFiveNumberSummary(_campus, _semester, "FY14").ToArray();
                var FyArray3 = GetFiveNumberSummary(_campus, _semester, "FY15").ToArray();
    
                int [][] FyArrayBox = new int[4][];
                FyArrayBox[0] = FyArray0;
                FyArrayBox[1] = FyArray1;
                FyArrayBox[2] = FyArray2;
                FyArrayBox[3] = FyArray3;
    
                foreach (var item in FyArrayBox)
                {
                    Debug.WriteLine(item);
                }
    
                return Json(FyArrayBox.ToArray());
            }
