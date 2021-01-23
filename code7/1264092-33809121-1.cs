    void DoStuff(Type type)
    {
        IWorkerClass<Base> worker_class = null;
    
        if(type == typeof(Derived1))
        {
            worker_class = new WorkerClass<Derived1>();  // NO compiler error
        }
        else if(type == typeof(Derived2))
        {
            worker_class = new WorkerClass<Derived2>();  // NO compiler error
        }
    
        // lots of common code with worker_class
        worker_class.DoStuff();
    }
