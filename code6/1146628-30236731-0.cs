    public Dictionary<int, string> GetLanguageSettingList()
        {
            Repository exrepo = new Repository(this.ConnectionString);
    
            return exrepo.GetLanguageSettingList().Where(c=>c.Id!=null).ToDictionary(c=>c.Id.Value, c=>c.Language);
        }
    
    
    public partial class LanguageList
    {
        public string Language { get; set; }
        public Nullable<int> Id { get; set; }
    }
