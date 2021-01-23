    private volatile CancellationTokenSource _tokenSource = new CancellationTokenSource();
    threadStartingPoint() {
    int index = 0;
    var token = _tokenSource.Token;
    while(index !== someMaxCondition && !token.IsCancellationRequested)
          ... // grab some data to work on
          lock(_lock) {  // lock index, so one access at a time
            index += index;
          }
          ... // do some stuff
          _mre.WaitOne(); // Pause if button Pause is pressed.
        }
    }
