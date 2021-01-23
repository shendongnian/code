      private async void LoadAsyncData() {
        IsBusy = true;
        var Pets  =  await GetPetsAsync();
        IsBusy = false;
      }
    
      private async Task<ObservableCollection<Pet>> GetPetsAsync() {
        var pets = await Task<ObservableCollection<Pet>>.Run(()=>{ 
           return _petService.GetPets();
        });
        return pets;       
      }
