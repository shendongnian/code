    IObservable<Result> SendRequest(Request request)
    {
        var subject = new AsyncSubject<Result>();
        NetworkComms.SendReqeust(request, result =>
        {
            subject.OnNext(result);
            subject.OnCompleted();
        });
        return subject.AsObservable();
    }
