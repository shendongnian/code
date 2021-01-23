    public class Credentials
    {
        public string Id { get; set; }
        public string FullId { get; set; }
        public string Year { get; set; }
        public string Country { get; set; }
        public string Company { get; set; }
    
        public Credentials(IEnumerable<Match> matches)
        {
            var properties = GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
    
            matches.ToList()
                   .ForEach(mt => properties.ForEach(prp => AssignValid(prp, mt, prp.Name)));
        }
    
        public void AssignValid(PropertyInfo prop, Match mt, string name)
        {
            if (mt.Groups[name]?.Success ?? false)
                prop.SetValue(this, (mt.Groups[name].Value));
        }
    }
