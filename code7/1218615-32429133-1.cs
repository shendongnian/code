    using System.Collections; 
    using System.Collections.Generic; 
    using System.Collections.ObjectModel; 
    using System.ComponentModel; 
    using System.Diagnostics.CodeAnalysis; 
    using System.Data.Entity; 
     
    namespace WinFormswithEFSample 
    { 
        public class ObservableListSource<T> : ObservableCollection<T>, IListSource 
            where T : class 
        { 
            private IBindingList _bindingList; 
     
            bool IListSource.ContainsListCollection { get { return false; } } 
     
            IList IListSource.GetList() 
            { 
                return _bindingList ?? (_bindingList = this.ToBindingList()); 
            } 
        } 
    }
