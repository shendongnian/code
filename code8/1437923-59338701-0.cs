     services.AddFactory<IProcessor, string>()
             .Add<ProcessorA>("A")
             .Add<ProcessorB>("B");
     public MyClass(IFactory<IProcessor, string> processorFactory)
     {
           var x = "A"; //some runtime variable to select which object to create
           var processor = processorFactory.Create(x);
     }
