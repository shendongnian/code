        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            var f = new DataGridItem();
            var firstselectedCategory = f.Categories.FirstOrDefault();
            if (firstselectedCategory != null)
            {
                f.SelectedCategory = firstselectedCategory;
                f.SelectedSubcategory =
                    f.Subcategories.FirstOrDefault(subcategory => subcategory.CategoryId == firstselectedCategory.Id);
            }
            else
            {
                f.SelectedCategory = null;
                f.SelectedSubcategory = null;
            }
            var s = new DataGridItem();
            var secondSelectedCategory = s.Categories.FirstOrDefault(category => !Equals(category, f.SelectedCategory));
            if (secondSelectedCategory != null)
            {
                s.SelectedCategory = secondSelectedCategory;
                s.SelectedSubcategory =
                    s.Subcategories.FirstOrDefault(subcategory => subcategory.CategoryId == secondSelectedCategory.Id);
            }
            else
            {
                s.SelectedCategory = null;
                s.SelectedSubcategory = null;
            }
            GridItems = new List<DataGridItem>
            {
                f,s,
            };
        #region
            //GridItems = new List<DataGridItem>
            //{
            //    new DataGridItem
            //    {
            //        SelectedCategory = new Category
            //        {
            //            Id = (Int32) CategoryKinds.Car,
            //            Name = "Car"
            //        },
            //        SelectedSubcategory = new Subcategory
            //        {
            //            Id = 2,
            //            Name = "Nissan",
            //            CategoryId = (Int32) CategoryKinds.Car
            //        }
            //    },
            //    new DataGridItem
            //    {
            //        SelectedCategory = new Category
            //        {
            //            Id = (Int32) CategoryKinds.Fruit,
            //            Name = "Fruit"
            //        },
            //        SelectedSubcategory = new Subcategory
            //        {
            //            Id = 4,
            //            Name = "Lemon",
            //            CategoryId = (Int32) CategoryKinds.Fruit
            //        }
            //    }
            //};
            #endregion
            _dataGrid.ItemsSource = GridItems;
        }
