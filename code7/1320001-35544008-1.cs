    public nodetoDBList (int temp) <- Constructor takes an int
    {
        elements = temp;
        next = null;
    }
    public void inserToList(object elements)
    {
        nodetoDBList newLink;
        newLink = new nodetoDBList (elements); <- passing in an object instead
    }
