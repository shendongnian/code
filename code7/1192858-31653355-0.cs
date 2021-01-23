    using System.Linq
    ...
    //Create a type to hold your grouped emails
    public class GroupedEmail
    {
        public int AlertCategory { get; set; }
    
        public IEnumerable<EmailBlock> EmailsInGroup {get; set; }
    }
    
    var grouped = myEmailData
        .GroupBy(e => e.alertCategory)
        .Select(g => new GroupedEmail
        {
            AlertCategory = g.Key,
            EmailsInGroup = g
        });
