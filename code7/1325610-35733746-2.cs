    public void SayHello()
    {
        try {
            _service.SayHello();
        } catch {
            _service = new HelloService();
                _service.SayHello();
        }
    }
