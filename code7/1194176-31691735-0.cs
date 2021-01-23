    class Test : IComparable<Test>
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public bool HasParentObject { get; set; }
    
        public int CompareTo(Test other)
        {
            if(other.HasParentObject && this.HasParentObject)
                return ParentId.CompareTo(other.ParentId);
            else if(other.HasParentObject)
                return 1;
            else 
                return -1; 
        }
    }
