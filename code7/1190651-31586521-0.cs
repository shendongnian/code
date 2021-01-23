    public class NewClass
    {
        public string Id{ get; set; }
        public string Description { get; set; }
        //......
    }
    db.Extras.ToList().ForEach(c => result.Add(x.Id, new NewClass(x.Id/*other field*/));
