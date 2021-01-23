         public class ViewModelAConductor 
         {
             private List<ViewModelA> rootViewModels = new List<ViewModelA>();
             public ViewModelAConductor()
             {
                  ViewModelA a1 = container.Resolvce<ViewModelA>(); 
                  rootViewModels.Add(a1);
                  ViewModelA a2 = container.Resolvce<ViewModelA>(); 
                  rootViewModels.Add(a2); 
             }
 
          
         }
         
         public class ViewModelA
         {
              ViewModelB viewModelB;
              IService service;
              public ViewModelA(IService service,ViewModelB viewModelB) 
              {
                  this.service = service;
                  this.viewModelB = viewModelB;
              }               
         }
         public class ViewModelB
         {
              ViewModelC viewModelC;
              IService service;
              public ViewModelA(IService service,ViewModelC viewModelC) 
              {
                  this.service = service;
                  this.viewModelC = viewModelC;
              }               
         }  
         public class ViewModelC
         {
              IService service;
              public ViewModelA(IService service) 
              {
                  this.service = service;                 
              }               
         }  
