    static class ObservableExtensions {
    
      public static IObservable<Unit> WriteToFile(this IObservable<Byte> source, String fileName) {
        return Observable.Create<Unit>(
          observer => {
            var fileStream = new SerialDisposable();
            return new CompositeDisposable(
              source.Subscribe(
                value => {
                  try {
                    if (fileStream.Disposable == null)
                      fileStream.Disposable = File.Create(fileName);
                    ((FileStream) fileStream.Disposable).WriteByte(value);
                  }
                  catch (SystemException ex) {
                    observer.OnError(ex);
                  }
                },
                observer.OnError,
                () => {
                  observer.OnNext(Unit.Default);
                  observer.OnCompleted();
                }
              ),
              fileStream
            );
          }
        );
      }
    
    }
