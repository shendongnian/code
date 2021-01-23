    private Foo()
    {
        this.os = System.IO.File.CreateText( "D:/tmp/test" );
        System.AppDomain.CurrentDomain.ProcessExit +=
            (sender, eventArgs) => this.os.Close();
    }
