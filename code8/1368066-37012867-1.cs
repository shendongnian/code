    public override void Execute(object item)
    {
      this.ViewModel.NewItem = new FilmModel();
      RaiseCanExecuteChanged();
    }
