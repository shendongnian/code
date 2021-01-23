        [Required]
        protected string ObjectTypeValue { get; set; }
        [NotMapped]
        public ObjectType Type
        {
            get { return ObjectType.Parse(ObjectTypeValue); }
            set { ObjectTypeValue = value.Print(); }
        }
