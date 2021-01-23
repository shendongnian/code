    protected Subject<Unit> Saved = new Subject<Unit>();
    
    protected override IObservable<bool> IsDirty() {
            return this.WhenAnyValue 
            (x => x.Firstname,
             x => x.LastName
            (f1, f2) => 
            f1 != this.Model.FirstName
            || f2 != this.Model.LastName
            ).Merge(Saved.Select(x => false));
    }
    
    protected override void SaveModel() {
        Model.FirstName = this.FirstName;
        Model.LastName = this.LastName;
        Save(Model); 
        this.Saved.OnNext(new Unit());
    }
