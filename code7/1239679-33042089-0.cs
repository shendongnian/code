    public abstract class DashboardModuleCommonSettings
    {
        public int ForwarderId { get; set; }
        public int ClientSubsidiaryId { get; set; }
        public bool IsContentUpdateable { get; set; }
        public int? AfterTime { get; set; }
        public string Title { get; set; }
        public string __marker__ { get; }
        public string ModuleSettingsPopupName { get; set; }
        public int ClientId { get; set; }
        public string CurrentLayout { get; set; }
    }
    public static class Extractor
    {
        public static IEnumerable<PropertyInfo> VisibleProperties<T>()
        {
            foreach (var p in typeof(T).GetProperties())
            {
                if ("__marker__".Equals(p.Name, StringComparison.InvariantCultureIgnoreCase)) yield break;
                yield return p;
            }
        }
    }
