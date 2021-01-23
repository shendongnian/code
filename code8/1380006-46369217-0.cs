        Pets = new ReactiveList<Pet>();
        
        GetPets = ReactiveCommand.Create<IEnumerable<Pet>>(async _ => {
         return await _service.GetPets();
        });
        
        GetPets.Subscribe(pets => {
            using(Pets.SuppressChangeNotifications()) // it's much easier to have one list and just change the items
            {
                Pets.Clear();
                foreach(var pet in pets)
                    Pets.Add(pet);
            }
        });
        
        GetPets.ThrownExceptions.Subscribe(ex =>{
            // show error to user, retry etc
        })
    
    _isBusy = GetPets.IsExecuting.ToProperty(this, x => x.IsBusy);
    
    // property definition
    bool IsBusy => _isBusy?.Value ?? false;
