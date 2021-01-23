      public class EditableList<TModel> : ObservableList<TModel>
            where TModel : class, INotifyPropertyChanged
        {
            #region Properties
    
            public List<TModel> EditedItems { get; set; }
            public List<TModel> AddedItems { get; set; }
            public List<TModel> DeletedItems { get; set; }
    
            public Boolean HasChanged
            {
                get
                {
                    return
                    (
                        this.EditedItems.Count > 0 ||
                        this.AddedItems.Count > 0 ||
                        this.DeletedItems.Count > 0
                    );
                }
    
            }
            #endregion
    
            #region Constructor
            public EditableList(IList<TModel> list)
                : base(list)
            {
                this.AddedItems = new List<TModel>();
                this.EditedItems = new List<TModel>();
                this.DeletedItems = new List<TModel>();
    
                this.CollectionChanged += EditableList_CollectionChanged;
    
                foreach (var item in list)
                    item.PropertyChanged += TModelEditableList_PropertyChanged;
            }
            public EditableList() : this(new List<TModel>()) { }
    
    
            #endregion
    
            #region Events
            void TModelEditableList_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
            {
                if (!(sender is TModel))
                    return;
    
                var entity = (TModel)sender;
    
                this.AddToEditedItems(entity);
              
            }
    
            void EditableList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                    foreach (TModel entity in e.NewItems)
                    {
                        this.AddToAddedItems(entity);
                    }
    
                else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
                    foreach (TModel entity in e.OldItems)
                    {
                        this.AddToDeletedItems(entity);
                    }
            }
    
            #endregion
    
            #region Methods
            public void AddToEditedItems(TModel entity)
            {
                if (!this.EditedItems.Contains(entity) && !this.AddedItems.Contains(entity))
                    this.EditedItems.Add(entity);
            }
            public void AddToAddedItems(TModel entity)
            {
                this.AddedItems.Add(entity);
                entity.PropertyChanged += TModelEditableList_PropertyChanged;
            }
            public void AddToDeletedItems(TModel entity)
            {
                if (this.EditedItems.Contains(entity))
                {
                    this.EditedItems.Remove(entity);
                    this.DeletedItems.Add(entity);
                }
                else if (this.AddedItems.Contains(entity))
                    this.AddedItems.Remove(entity);
                else
                    this.DeletedItems.Add(entity);
            }
            public void ClearEditHistory()
            {
                this.EditedItems.Clear();
                this.AddedItems.Clear();
                this.DeletedItems.Clear();
            }
            #endregion
        }
