    public interface IObservable<out TValue, in TResult> {
       IDisposable Subscribe(IObserver<TValue, TResult> objObserver);
    }
    
    
    
    internal class SelectiveSubject<T> : IObserver<T>, IObservable<T, bool> {
       private readonly LinkedList<IObserver<T, bool>> _ObserverList;
    
       public SelectiveSubject() {
          _ObserverList = new LinkedList<IObserver<T, bool>>();
       }
    
       public void OnNext(T value) {
          lock(_ObserverList) {
             foreach(IObserver<T, bool> objObserver in _ObserverList) {
                if(objObserver.OnNext(value)) {
                   break;
                }
             }
          }
       }
    
       public void OnError(Exception exception) {
          lock(_ObserverList) {
             foreach(IObserver<T, bool> objObserver in _ObserverList) {
                if(objObserver.OnError(exception)) {
                   break;
                }
             }
          }
       }
    
       public void OnCompleted() {
          lock(_ObserverList) {
             foreach(IObserver<T, bool> objObserver in _ObserverList) {
                if(objObserver.OnCompleted()) {
                   break;
                }
             }
          }
       }
    
       public IDisposable Subscribe(IObserver<T, bool> objObserver) {
          LinkedListNode<IObserver<T, bool>> objNode;
          lock(_ObserverList) {
             objNode = _ObserverList.AddLast(objObserver);
          }
          return Disposable.Create(() => {
             lock(objNode.List) {
                objNode.List.Remove(objNode);
             }
          });
       }
    }
    
    
    
    public static IObservable<T, bool> ToSelective<T>(this IObservable<T> objThis) {
       var objSelective = new SelectiveSubject<T>();
       objThis.Subscribe(objSelective);
       return objSelective;
    }
