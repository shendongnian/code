    public class First {
        [Key]
        public int ProdId { get; set; }
        public string Supplier { get; set; }
        [NotMapped]
        public virtual IList<PsLog> PsLogs
            {
                get
                {
                    using (var context = new PSDataContext())
                    {
                        return context.PsLogs.ToList();
                    }
                }
            }
        [NotMapped]
        public bool IsSavedForLater
            {
                get
                {
                    return Logs.Where(l =>
                    {
                        var content = l.LogContent.JsonStringToObject<History>();
                        return (content.ProdId == ProdId && l.TableName == "Condition");
                    }).Any();
                }
            }
    }
