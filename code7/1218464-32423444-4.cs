      public class SomeEntityViewModel : NotificationObject
      {
           private SomeEntity _someEntity;
           public  SomeEntity SomeEntity
           {
               get{ return _someEntity;}
               set
               {
                   _someEntity = value;
                   RaisePropertyChanged("SomeEntity");
               }  
           }  
      } 
