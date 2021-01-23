    class MyMessage
     {
          ObservableCollections col1 {get;set;}
          ObservableCollections col2 {get;set;}
          ObservableCollections col3 {get;set;}
        public MyMessage(ObservableCollections col1, ObservableCollections col2, ObservableCollections col3)
        {
           this.Col1 = col1;
           this.Col2 = col2;
           this.Col3 = col3;
         }
     }
    class viewmodelA
     {
        void someFunc()
         {
           Messenger.Default.Send(new MyMessage (collection1, collection2, collection3);
         }
     }
    class viewmodelB
     {
          viewmodelB()
          {
            Messenger.Default.Register<MyMessage > (this, message => DoSomething(message);
          }
          
          public void DoSomething(MyMessage message)
             {
                 //use your collections
              }
     } 
