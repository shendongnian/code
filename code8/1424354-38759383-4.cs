    public partial class Window1 : INotifyPropertyChanged {
    
            private Category _selectedCategory;
            private ObservableCollection<Category> _categories = new ObservableCollection<Category>();
            private Category _selectedSubCategory;
    
            public Window1() {
                InitializeComponent();
                var cat = new Category() { Name = "Category 1" };
                cat.SubCategories.Add(new Category { Name = "Cat 1 - Subcat 1" });
                cat.SubCategories.Add(new Category { Name = "Cat 1 - Subcat 2" });
                cat.SubCategories.Add(new Category { Name = "Cat 1 - Subcat 3" });
                var cat2 = new Category() { Name = "Category 2" };
                cat2.SubCategories.Add(new Category { Name = "Cat 2 - Subcat 1" });
                cat2.SubCategories.Add(new Category { Name = "Cat 2 - Subcat 2" });
                var cat3 = new Category() { Name = "Category 3" };
                cat2.SubCategories.Add(new Category { Name = "Cat 3 - Subcat 2" });
                this.Categories.Add(cat);
                this.Categories.Add(cat2);
                this.Categories.Add(cat3);
                this.SelectedCategory = this.Categories.First();
                this.DataContext = this;
            }
    
            public ICommand AddCatCommand => new RelayCommand(x => {
                var newCat = new Category { Name = "Im New" };
                newCat.SubCategories.Add(new Category { Name = "I'm new too" });
                this.Categories.Add(newCat);
            });
    
            public Category SelectedCategory {
                get { return _selectedCategory; }
                set {
                    if (Equals(value, _selectedCategory)) return;
                    _selectedCategory = value;
                    OnPropertyChanged();
                }
            }
    
            public Category SelectedSubCategory {
                get { return _selectedSubCategory; }
                set {
                    if (Equals(value, _selectedSubCategory)) return;
                    _selectedSubCategory = value;
                    OnPropertyChanged();
                }
            }
    
            public ObservableCollection<Category> Categories => this._categories;
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            [NotifyPropertyChangedInvocator]
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
