    private void m1()
    {
        byte[] result = ServerWC.UploadValues("http://localhost", this.srvNvc);
        Console.WriteLine(Encoding.ASCII.GetString(result));
    }
    private void m2()
    {
        Console.WriteLine(Encoding.ASCII.GetString(ServerWC.UploadValues("http://localhost", this.srvNvc)));
    }
