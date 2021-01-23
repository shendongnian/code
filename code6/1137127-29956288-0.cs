    namespace some.type.library;
    {
     class SpecialCreator:Creator
     {
      override public SomeObject createObject()
      {
        doSomethingSpecial();  
        return new SomeObject();
      }
     }
    }
