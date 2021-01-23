      public class SomeEntityContainerViewModel : NotificationObject
      {
          public ObservableCollection<SomeEntityViewModel> Items;
          public void async OnRequestNewEntity() 
          {
             SomeEntity newEntity = await _someEntityService.CreateSomeEntityAsync();
             var vm = new SomeEntityViewModel{ SomeEntity = newEntity};
             Items.add(vm);
          }
      }
