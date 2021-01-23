    ObservableCollecton<Item> Items 
    {
      get{ this._items; }
      set{ 
        if (this._items != value) 
        {
          this._items = value;
          NotifyPropertyChanged(()=>Items);
        }
      }
    }
    
    void Sort()
    {
      var temp = new ObservableCollection<Item>(Items.Take(1).Union(Items.Skip(1).OrderBy(item => item.Id)));
      Items = temp;
    }
