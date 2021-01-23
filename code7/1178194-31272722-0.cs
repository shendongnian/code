    // just use Task.Run to "background" the work
    var src = Observable
        .Create<CanFrame>((observer, cancellationToken) => Task.Run(() =>
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var frame = _Socket.ReadFrame();
                if (frame == null) // end of stream?
                {
                    // will send a Completed event
                    return;
                }
                observer.OnNext(frame);
            }
        }));
    var d = src.Subscribe(s => s.Dump());
    Console.ReadLine();
    d.Dispose();
