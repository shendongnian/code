    public void Test() {
        Task.Run(() => DoSomething());
    }
    private void DoSomething() {
        //Do Something here....
        //Do Something again...
        Task.Run(() => DoSomething());
    }
