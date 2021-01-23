     _eventAggregator.GetEvent<MyEvent<IRequest>>().Subscribe(Received);
     
     private void Received(IMyClass<IRequest> obj)
     {
            
     }
    _eventAggregator.GetEvent<MyEvent<IRequest>>().Publish(new MyClass<Profile>());
