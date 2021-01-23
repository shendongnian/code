    public Form1()
    {
        st = new store(test);
    }
    private int testPrivate { get; set; }
    public int test
    {
        get { return testPrivate; }
        set
        {
            testPrivate = value;
            st.o = value;
        }
    }
    public store st { get; set; }
