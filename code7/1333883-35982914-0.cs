    using DevExpress.Mvvm.POCO;
    //...
    public class ListViewModel {
        public ObservableCollection<Contact> GridData { get; private set; }
        // mark the SelectedEntities property as virtual to be notified on initializing/replacing
        public virtual ObservableCollection<Contact> SelectedEntities { get; private set; }
        // unsubscribe the CollectionChanged event in changing-callback
        protected void OnSelectedEntitiesChanging() {
            if(SelectedEntities != null)
                SelectedEntities.CollectionChanged -= SelectedEntities_CollectionChanged;
        }
        // subscribe the CollectionChanged event in changed-callback
        protected void OnSelectedEntitiesChanged() {
            if(SelectedEntities != null)
                SelectedEntities.CollectionChanged += SelectedEntities_CollectionChanged;
            UpdateSelectedEntitiesDependencies();
        }
        void UpdateSelectedEntitiesDependencies() {
            // Raise INPC for dependent properties
            this.RaisePropertyChanged(x => x.IsSingeselect);
            this.RaisePropertyChanged(x => x.IsMultiSelect);
            // Raise INPC for dependent properties of child ViewModels
            foreach(var item in ContextMenuItems)
                item.RaisePropertyChanged(x => x.Enabled);
        }
        void SelectedEntities_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
            if(e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Reset)
                UpdateSelectedEntitiesDependencies();
        }
        public bool IsSingeselect { get { return SelectedEntities.Count == 1; } }
        public bool IsMultiSelect { get { return SelectedEntities.Count > 0; } }
        public ObservableCollection<MenuComandViewModel> ContextMenuItems { get; private set; }
    }
    public class MenuComandViewModel {
        public bool Enabled {
            get {
                var parentViewModel = this.GetParentViewModel<ListViewModel>();
                return parentViewModel.IsMultiSelect; // Some implementation
            }
        }
    }
