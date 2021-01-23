    public class ViewModel : IViewModel {
    
      public PageData PageData { get; set; }
      public YOURINTERFACE ViewData { get; set; }
    
      public ViewModel(YOURINTERFACE viewData, PageData pageData) {
        PageData = pageData;
        ViewData = viewData;
      }
    }
