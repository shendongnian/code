    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    namespace ComboDemo.ViewModels
    {
        public class ViewModelBase : INotifyPropertyChanged
        {
            #region INotifyPropertyChanged
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged([CallerMemberName] String propName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
            }
            #endregion INotifyPropertyChanged
        }
        public class ComboDemoViewModel : ViewModelBase
        {
            //  In practice this would probably have a public (or maybe protected) setter 
            //  that raised PropertyChanged just like the other properties below. 
            public ObservableCollection<CategoryViewModel> Categories { get; } 
                = new ObservableCollection<CategoryViewModel>();
            #region SelectedCategory Property
            private CategoryViewModel _selectedCategory = default(CategoryViewModel);
            public CategoryViewModel SelectedCategory
            {
                get { return _selectedCategory; }
                set
                {
                    if (value != _selectedCategory)
                    {
                        _selectedCategory = value;
                        OnPropertyChanged();
                    }
                }
            }
            #endregion SelectedCategory Property
            public void Populate()
            {
                #region Fake Data
                foreach (var x in Enumerable.Range(0, 5))
                {
                    var ctg = new ViewModels.CategoryViewModel($"Category {x}");
                    Categories.Add(ctg);
                    foreach (var y in Enumerable.Range(0, 5))
                    {
                        ctg.SubCategories.Add(new ViewModels.SubCategoryViewModel($"Sub-Category {x}/{y}"));
                    }
                }
                #endregion Fake Data
            }
        }
        public class CategoryViewModel : ViewModelBase
        {
            public CategoryViewModel(String name)
            {
                Name = name;
            }
            public ObservableCollection<SubCategoryViewModel> SubCategories { get; } 
                = new ObservableCollection<SubCategoryViewModel>();
            #region Name Property
            private String _name = default(String);
            public String Name
            {
                get { return _name; }
                set
                {
                    if (value != _name)
                    {
                        _name = value;
                        OnPropertyChanged();
                    }
                }
            }
            #endregion Name Property
            //  You could put this on the main viewmodel instead if you wanted to, but this way, 
            //  when the user returns to a category, his last selection is still there. 
            #region SelectedSubCategory Property
            private SubCategoryViewModel _selectedSubCategory = default(SubCategoryViewModel);
            public SubCategoryViewModel SelectedSubCategory
            {
                get { return _selectedSubCategory; }
                set
                {
                    if (value != _selectedSubCategory)
                    {
                        _selectedSubCategory = value;
                        OnPropertyChanged();
                    }
                }
            }
            #endregion SelectedSubCategory Property
        }
        public class SubCategoryViewModel : ViewModelBase
        {
            public SubCategoryViewModel(String name)
            {
                Name = name;
            }
            #region Name Property
            private String _name = default(String);
            public String Name
            {
                get { return _name; }
                set
                {
                    if (value != _name)
                    {
                        _name = value;
                        OnPropertyChanged();
                    }
                }
            }
            #endregion Name Property
        }
    }
