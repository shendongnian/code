    public class Category
    {
        public int CategoryId {get; set;}
        public int ParentId {get; set;}
        public string Name {get; set;}
        public string GetFullCategoryName()
        {
            string result = this.Name;
            // note: I removed the argument because it's class member.
            Category parent = this.GetParent(); // null for top level Categories
            
            while (parent != null)
            {
                result = parent.Name + " >> " + result;
                parent = GetParent(parent.ParentId);
            }
            return result;
        }
        public Category GetParent()
        {
            // note: I just made this up, you would use whatever EF method you have...
            return EF.GetEntity<Category>(this.ParentId);
        }
    }
