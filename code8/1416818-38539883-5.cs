    using System;
    using System.Collections.Generic;
    using System.Reactive.Disposables;
    using System.Reactive.Linq;
    
    namespace ObservableNumberGenerator.ObservableImplementationReliesOnOperator.Hot
    {
        public class RandomNumbers : IObservable<int>, IDisposable
        {
            protected Random _random = null;
            protected int _maxNumbersToGenerate;
            protected int _startAfterMilliseconds = 1000;
            protected int _generateEveryMilliseconds = 1000;
    
            protected List<IObserver<int>> _observers = 
                                new List<IObserver<int>>();
    
            protected IObservable<int> _innerObservable = null;
            protected IDisposable _innerSubscription = null;
            protected bool _completed = false;
            private bool disposedValue = false;
    
            public RandomNumbers(int maxNumbersToGenerate,
                int startAfterMilliseconds = 1000, int generateEveryMilliseconds = 1000)
            {
                _maxNumbersToGenerate = maxNumbersToGenerate;
                _startAfterMilliseconds = startAfterMilliseconds;
                _generateEveryMilliseconds = generateEveryMilliseconds;
    
                _random = new Random();
    
                _innerObservable = Observable
                    .Timer(
                      TimeSpan.FromMilliseconds(_startAfterMilliseconds),
                      TimeSpan.FromMilliseconds(_generateEveryMilliseconds))
                    .Select(v => GenerateNumber())
                    .Take(_maxNumbersToGenerate);
    
                _innerSubscription = 
                    _innerObservable.Subscribe(OnNext, OnError, OnCompleted);
            }
    
            protected virtual void OnCompleted()
            {
                _completed = true;
    
                foreach (var observer in _observers)
                    observer.OnCompleted();
            }
    
            protected virtual void OnError(Exception ex)
            {
                _completed = true;
    
                foreach (var observer in _observers)
                    observer.OnError(ex);
            }
    
            protected virtual void OnNext(int value)
            {
                foreach (var observer in _observers)
                    observer.OnNext(value);
            }
    
            protected virtual int GenerateNumber()
            {
                return _random.Next();
            }
    
            public IDisposable Subscribe(IObserver<int> observer)
            {
                if (observer == null) throw new ArgumentNullException("observer");
    
                _observers.Add(observer);
    
                if (_completed)
                {
                    observer.OnCompleted();
                }
    
                return Disposable.Empty;
            }
    
            protected virtual void Dispose(bool disposing)
            {
                if (!disposedValue)
                {
                    if (disposing)
                    {
                        _innerSubscription.Dispose();
                    }
    
                    disposedValue = true;
                }
            }
    
            public void Dispose()
            {
                Dispose(true);
            }
        }
    }
