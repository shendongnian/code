    public class ProducerObservable : IObservable<Message>, IDisposable {
       private readonly Producer _Producer;
       private readonly Subject<Message> _Subject;
    
       public ProducerObservable() {
          _Produder = new Producer();
          _Producer.Attach(Message_Received);
          _Subject = new Subject<Message>();
          _Producer.Start();
       }
    
       public void Dispose() {
          _Producer.Dispose();
          _Subject.Dispose();
       }
    
       public IDisposable Subscribe(IObserver<Message> objObserver) {
          return _Subject.Subscribe(objObserver);
       }
    
       private void Message_Received(Message objMessage) {
          _Subject.OnNext(objMessage);
       }
    }
