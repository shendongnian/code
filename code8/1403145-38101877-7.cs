    using (var myDisposables = GetMyDisposables()) {
        foreach (var myDisposable in myDisposables.Members) {
            DoSomething(myDisposable);
            DoSomethingElse(myDisposable);
        }
    }
    static CollectionOfDisposable<MyDisposable> GetMyDisposables() {
        throw new NotImplementedException(); // return a list of MyDisposable objects
    }
