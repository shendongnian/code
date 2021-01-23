     public interface IView 
     {
         event EventHandler Initialise;
         void SetData(MyData data)
     }
     public class Presenter
     {
        ....
  
         public Presenter(IView view ) 
         { 
             _view = view;
             _view.Initialise += OnViewInitialise; 
         }
         public void OnViewInitialise() 
         {
              var data = _repository.GetData();
              _view.SetData(data);
         }
     }
