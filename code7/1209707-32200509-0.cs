	namespace System.ComponentModel
	{
	    [AttributeUsage(AttributeTargets.All)]
	    public class CategoryAttribute : Attribute
	    {
	        public CategoryAttribute(string category)
	        {
	            Category = category;
	        }
	        public string Category { get; private set; }
	        public override bool Equals(object obj)
	        {
	            if (obj == this)
	                return true;
	            var other = obj as CategoryAttribute;
	            return other != null && other.Category == Category;
	        }
	        public override int GetHashCode()
	        {
	            return Category.GetHashCode();
	        }
	    }
	}
