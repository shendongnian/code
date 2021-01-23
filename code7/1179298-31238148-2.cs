    using System.Linq;
    using System.Collections.Generic;
    
    struct ImageItem {
        public string Title { get; set; }
        public string Name { get; set; }
    }
    
    bool Contains(string toSearch, string x) {
        return toSearch != null && toSearch.ToLower().Contains(x);
    }
    
    IEnumerable<ImageItem> FilterItems(IEnumerable<string> targetKeywords, IEnumerable<ImageItem> items) {
        return items.Where(item => targetKeywords.All(x => Contains(item.Name, x) || Contains(item.Title, x)));
        
    }
