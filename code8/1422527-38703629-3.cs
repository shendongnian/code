    public ObservableCollection<Item> AllItems { get; set; }
    public Item MySelectedItem 
    { get; 
      set 
      {
         AllItems.ForEach(x => { x.IsExtraControlsVisible = false; });
         AllItems.First(x => x.Id == value.Id).IsExtraControlsVisible = true;
      }
    }
