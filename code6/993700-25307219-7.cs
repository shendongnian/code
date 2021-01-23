    var m_subject = new SubscribeLastSubject<string>();
            
    m_subject.ObserveOn(Scheduler.CurrentThread).Subscribe(s => Console.WriteLine("firstSubscription"));
    m_subject.ObserveOn(Scheduler.CurrentThread).SubscribeLast(s => Console.WriteLine("secondSubscription"));
    m_subject.ObserveOn(Scheduler.CurrentThread).Subscribe(s => Console.WriteLine("thirdSubscription"));
            
    m_subject.OnNext("1");
    Console.ReadKey();
