    public static void Test(ref Node node) {
        node = null;
    }
    // Usage
    Node parent = ...
    Test( ref parent );
    Assert( parent == null );
