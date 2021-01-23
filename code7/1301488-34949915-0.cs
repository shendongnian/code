    BlockingCollection<IResult> blockingQueue ..
    // Producer Task
    IResult Process(IInputRequest params)
    {
       if (...)
    }
    
    // Consuming Task
    foreach ( .. blockingQueue.GetConsumerable...)
    {
    }
   
