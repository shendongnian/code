    var closeObservable = Observable.FromEvent<Action<byte[]>, byte[]>(
        action => action.Invoke, 
        h => socket.OnClose+= h, 
        h => socket.OnClose -= h);
    var msgObservable = Observable.FromEvent<Action<byte[]>, byte[]>(
        action => action.Invoke, 
        h => socket.OnMessage += h, 
        h => socket.OnMessage -= h);
    msgObservable.TakeUntil(closeObservable)
