     SomeClass someClass = new SomeClass();
     provider.Subscribe(someClass);
     while (!someClass.Value) {
         provider.GetEvents();
     }
     class SomeClass {
         public Value { get; private set; }
         public void OnNext(object someUpdatedValue)
         {
            Value = true;
         }
     }
