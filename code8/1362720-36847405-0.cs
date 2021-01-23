    public class UnitReportPairGenerateValsModel
    {
        public GenerateVals[] generatevals { get; set; }
 
    UnitReportPairGenerateValsModel.GenerateVals[] generateVals =
        (from DataRow row in UnitReportPairGenerateValsDT.Rows
            select new UnitReportPairGenerateValsModel.GenerateVals
            {
                DayOfMonth = Convert.ToInt32(row["DayOfMonth"]),
                PatternOrdinal = row["PatternOrdinal"].ToString(),
                PatternDOW = row["PatternDOW"].ToString(),
                PatternInterval = row["PatternInterval"].ToString()
            }).ToArray();
