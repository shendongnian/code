        private string selectedCategory;
        public string SelectedCategory
        {
            get { return this.selectedCategory; }
            set
            {
                if (this.SetProperty(ref this.selectedCategory, value))
                {
                    if (value.Equals("Category1"))
                    {
                        this.SubCategories.Clear();
                        this.SubCategories.Add("Category1 Sub1");
                        this.SubCategories.Add("Category1 Sub2");
                    }
                    if (value.Equals("Category2"))
                    {
                        this.SubCategories.Clear();
                        this.SubCategories.Add("Category2 Sub1");
                        this.SubCategories.Add("Category2 Sub2");
                    }
                }
            }
        }
        public ObservableCollection<string> Categories { get; set; } = new ObservableCollection<string> { "Category1", "Category2" };
        public ObservableCollection<string> SubCategories { get; set; } = new ObservableCollection<string>();
