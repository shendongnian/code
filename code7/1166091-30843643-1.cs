    public List<LookupData> HeatingTypeData { get; set; }
        public static List<LookupData> GetHeatingType()
        {
            return LookupData.GetDataList("HeatingType").OrderBy(m => m.SortOrder).ToList();
        }
