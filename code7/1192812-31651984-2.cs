    public interface IItemType
    {
        object Item1{ get; set; }
        object Item2{ get; set; }
        object Item3{ get; set; }
    }
    public class ItemType : IItemType
    {
        public int ItemTypeCategoryId { get; set; }
        public int ItemTypeDetailId { get; set; }
        public string TypeName { get; set; }
        public object Item1
        {
            get
            {
                return ItemTypeCategoryId;
            }
            set
            {
                ItemTypeCategoryId = Convert.ToInt32(value);
            }
        }
        public object Item2
        {
            get
            {
                return ItemTypeDetailId;
            }
            set
            {
                ItemTypeDetailId = Convert.ToInt32(value);
            }
        }
        public object Item3
        {
            get
            {
                return TypeName;
            }
            set
            {
                TypeName = value.ToString();
            }
        }
    }
    public class ItemTypeCategory : IItemType
    {
        public int ItemTypeCategoryId { get; set; }
        public string CategoryName { get; set; }
        public object Item1
        {
            get
            {
                return ItemTypeCategoryId;
            }
            set
            {
                ItemTypeCategoryId = Convert.ToInt32(value);
            }
        }
        public object Item2
        {
            get
            {
                return CategoryName;
            }
            set
            {
                CategoryName = value.ToString();
            }
        }
        public object Item3{ get; set; }
    }
    public class ItemTypeDetail : IItemType
    {
        public int ItemTypeDetailId { get; set; }
        public string ItemTypeDetailName { get; set; }
        public object Item1
        {
            get
            {
                return ItemTypeDetailId;
            }
            set
            {
                ItemTypeDetailId = Convert.ToInt32(value);
            }
        }
        public object Item2
        {
            get
            {
                return ItemTypeDetailName;
            }
            set
            {
                ItemTypeDetailName = value.ToString();
            }
        }
        public object Item3 {get;set;}
    }
