    // in class
    public ReactiveCommand<Unit> SaveCommand { get; }
    
    private readonly ObservableAsPropertyHelper<bool> _isDirty;
    public bool IsDirty { get { return _isDirty.Value; } }
    
    
    // in constructor
    this.SaveCommand = ReactiveCommand.CreateAsyncTask(_ => 
    {
    	Model.FirstName = this.FirstName;
        Model.LastName = this.LastName;
        Save(Model); // this could be an async method
    	return Task.FromResult(Unit.Default);
    });
    
    this.WhenAnyValue(
        vm => vm.Firstname,
        vm => vm.LastName,
    	(f1, f2) => Unit.Default)
    	.Merge(this.SaveCommand)
    	.Select(_ => this.FirstName != this.Model.FirstName 
                  || this.LastName != this.Model.LastName)
    	.ToProperty(this, vm => vm.IsDirty, out _isDirty);
