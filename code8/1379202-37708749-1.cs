    public class ShellViewModel : Conductor<IScreen>.Collection.OneActive
    {
      public ShellViewModel(IEnumerable<IScreen> viewmodels)
      {
      //omitted for brevity. 
      }
      public void Select(object datacontext)
      {
          var vm = datacontext as IScreen;
          if (vm != null && Items.Contains(vm))
          {
             if (vm.IsActive)
               return;
             ActivateItem(vm);
             vm.Refresh();
          }
          else
          {
             var vm2 = datacontext as Screen;
             if (vm2 != null)
             {
               (vm2.Parent as IConductActiveItem)?.ActivateItem(vm2);
                vm2.Refresh();
             }
          }
       }       
     }
