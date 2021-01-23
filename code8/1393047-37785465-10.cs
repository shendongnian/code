    public class Publisher
    {
        public IObservable<CancelationToken> SomeEvent {get;}
    }
    
    public abstract class Subscriber
    {
        public abstract IObservable<CancelationToken> Subscribe(IObservable<CancelationToken> observable);
        
    }
    
    IEnumerable<Subscriber> subscribers = ...
    Publisher publisher = ...
    
    IDisposable subscription = subscribers.Aggregate(publisher.SomeEvent, (e, sub) => sub.Subscribe(e)).Subscribe();
    
    //Dispose the subscription when you want to stop listening.
