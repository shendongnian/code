    public class Link
        {
        public string Version {get;set;}
        public string Value {get;set;}
        }
        
        Use it Like
        List<Link> linkList = new List<Link>();
        linkList.AddRange(OldValues)
        linkList.AddRange(OldValues)
        
        var oldList = linkList.Where(l=>l.Version.eqals("old")).toList();
        var newList = linkList.Where(l=>l.Version.eqals("new")).toList()
