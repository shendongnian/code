    public class ItemType : INotifyPropertyChanged
    {
        public string Name { get; set; // Raise property changed event }
        public string IsDeleted { get; set; // Raise property changed event }
    
        //// Other properties
        
        public List<ItemType> Children { get; set; }
    
        //// Filter based on provided perdicate
        public Node Search(Func<Node, bool> predicate)
        {
             if(this.Children == null || this.Children.Count == 0)
             {
                 if (predicate(this))
                    return this;
                 else
                    return null;
             }
             else 
             {
                 var results = Children
                                   .Select(i => i.Search(predicate))
                                   .Where(i => i != null).ToList();
    
                 if (results.Any()){
                    var result = (Node)MemberwiseClone();
                    result.Items = results;
                    return result;
                 }
                 return null;
             }             
        }
    }
