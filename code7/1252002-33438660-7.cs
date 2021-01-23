    #region Assembly WindowsBase.dll, v3.0.0.0
    // C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\v3.0\WindowsBase.dll
    #endregion
    
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel;
    
    namespace System.Collections.ObjectModel
    {
        [Serializable]
        public class ObservableCollection<T> : Collection<T>, INotifyCollectionChanged, INotifyPropertyChanged
        {
            public ObservableCollection();   
            public ObservableCollection(IEnumerable<T> collection);
            public ObservableCollection(List<T> list);
            //....
