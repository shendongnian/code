    using MonoTouch.ObjCRuntime;
    using MonoTouch.Foundation;
    using System;
    
    namespace MyNamespace
    {
      [BaseType (typeof (NSObject))]
      interface MyObjCWrapper
      {
        [Export("initWithArg1:arg2:arg3:")]
        void Constructor(string first, string second, string third);
    
        [Export("mySelectorTaking1arg:")] // note colon, takes 1 arg
        void DoSomethingWith1Arg(string filePath);
    
        [Export("getSomething")] // note no colon, takes 0 args
        int GetSomething();
    }
