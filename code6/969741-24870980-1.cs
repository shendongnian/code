    public class BindingViewModelList<TViewModel, TModel> : BindingList<TViewModel>
    {
        private readonly ObservableCollection<TModel> _source;
        private readonly Func<TModel> _modelFactory;
        private readonly Func<TModel, TViewModel> _viewModelFactory;
        private readonly Func<TViewModel, TModel> _getWrappedModel;
        private bool isSync = false;
        public BindingViewModelList(ObservableCollection<TModel> source, Func<TModel, TViewModel> viewModelFactory, Func<TModel> modelFactory, Func<TViewModel, TModel> getWrappedModel)
            : base(source.Select(model => viewModelFactory(model)).ToList())
        {
            Contract.Requires(source != null);
            Contract.Requires(viewModelFactory != null);
            this._source = source;
            this._modelFactory = modelFactory;
            this._viewModelFactory = viewModelFactory;
            this._getWrappedModel = getWrappedModel;
            this._source.CollectionChanged += OnSourceCollectionChanged;
            this.AddingNew += BindingViewModelList_AddingNew;
        }
        protected virtual TModel CreateModel()
        {
            return _modelFactory.Invoke(); 
        }
        protected virtual TViewModel CreateViewModel(TModel model)
        {
            return _viewModelFactory(model);
        }
        private void BeginSync()
        {
            this.isSync = true;
        }
        private void EndSync()
        {
            this.isSync = false;
        }
        void BindingViewModelList_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = CreateViewModel(CreateModel());
        }
        protected override void OnListChanged(ListChangedEventArgs e)
        {
            if (!this.isSync)
            {
                if (e.NewIndex >= 0 && e.NewIndex < this.Count)
                {
                    bool ok = true;
                    TViewModel item = default(TViewModel);
                    try
                    {
                        item = this[e.NewIndex];
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        ok = false;
                    }
                    if (ok)
                    {
                        switch (e.ListChangedType)
                        {
                            case ListChangedType.ItemMoved:
                                BeginSync();
                                this._source.Move(e.OldIndex, e.NewIndex);
                                EndSync(); 
                                break;
                            case ListChangedType.ItemAdded:
                                TModel modelAdded = _getWrappedModel(item);
                                BeginSync();
                                this._source.Add(modelAdded);
                                EndSync();
                                break;
                            case ListChangedType.ItemChanged:
                                //TModel modelChanged = _getWrappedModel(item);
                                //BeginSync();
                                //this._source[e.NewIndex] = modelChanged; 
                                //EndSync(); 
                                break;
                            case ListChangedType.Reset:
                                BeginSync();
                                this._source.Clear();
                                for (int i = 0; i < this.Count; i++)
                                {
                                    TModel model = _getWrappedModel(this[i]);
                                    this._source.Add(model);
                                }
                                EndSync();
                                break;
                        }
                    }
                }
            }
            base.OnListChanged(e);
        }
        protected override void RemoveItem(int index)
        {
            if (!isSync) {
                TModel model = _getWrappedModel(this[index]);
                BeginSync();
                this._source.Remove(model);
                EndSync();
            }
            base.RemoveItem(index);
        }
        private void OnSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (isSync) return;
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    BeginSync();
                    for (int i = 0; i < e.NewItems.Count; i++)
                    {
                        this.Insert(e.NewStartingIndex + i, CreateViewModel((TModel)e.NewItems[i]));
                    }
                    EndSync();
                    break;
                case NotifyCollectionChangedAction.Move:
                    if (e.OldItems.Count == 1)
                    {
                        BeginSync();
                        this.Swap(e.OldStartingIndex, e.NewStartingIndex);
                        EndSync();
                    }
                    else
                    {
                        List<TViewModel> items = this.Skip(e.OldStartingIndex).Take(e.OldItems.Count).ToList();
                        BeginSync();
                        for (int i = 0; i < e.OldItems.Count; i++)
                            this.RemoveAt(e.OldStartingIndex);
                        for (int i = 0; i < items.Count; i++)
                            this.Insert(e.NewStartingIndex + i, items[i]);
                        EndSync();
                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    BeginSync();
                    for (int i = 0; i < e.OldItems.Count; i++)
                        this.RemoveAt(e.OldStartingIndex);
                    EndSync();
                    break;
                    
                case NotifyCollectionChangedAction.Replace:
                    // remove
                    BeginSync();
                    for (int i = 0; i < e.OldItems.Count; i++)
                        this.RemoveAt(e.OldStartingIndex);
                    // add
                    for (int i = 0; i < e.NewItems.Count; i++)
                        this.Insert(e.NewStartingIndex + i, CreateViewModel((TModel)e.NewItems[i]));
                    EndSync();
                    break;
                case NotifyCollectionChangedAction.Reset:
                    BeginSync(); 
                    Clear();
                    for (int i = 0; i < e.NewItems.Count; i++)
                        this.Add(CreateViewModel((TModel)e.NewItems[i]));
                    EndSync();
                    break;
                default:
                    break;
            }
        }
        public void Swap(int first, int second)
        {
            TViewModel temp = this[first];
            this[first] = this[second];
            this[second] = temp;
        }
    }
