    public class LookupData : ILookup
        {
            public string LookupCode { get; set; }
            public string LookupDescription { get; set; }
            public int SortOrder { get; set; }
    
            public static List<LookupData> GetDataList(string LookupGroup)
            {
                DBContexts.VoidsDBContext context = new DBContexts.VoidsDBContext();
                var Params = new SqlParameter { ParameterName = "LookupGroup", Value = LookupGroup };
                return context.Database.SqlQuery<LookupData>("p_LookupList @LookupGroup", Params).ToList();
            }
        }
