    [Permission(Permissions.ManageCategories)]
    class UpdateCategory {
        [NonEmptyGuid]
        public Guid CategoryId;
        [Required, ValidateObject]
        public CategoryData Data;
    }
    class CategoryData {
        [NonEmptyGuid]
        public Guid CategoryTypeId;
        [Required, StringLength(250)]
        public string Description;
    }
