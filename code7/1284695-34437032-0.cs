        private Subcategory SelectedSubcategoryM;
        public Subcategory SelectedSubcategory
        {
            get
            {
                return this.SelectedSubcategoryM;
            }
            set
            {
                this.SelectedSubcategoryM = (from aTest in this.Subcategories
                                            where aTest.Id == value.Id
                                            select aTest).Single();
            }
        }
