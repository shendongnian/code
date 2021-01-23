    class Position {
        public int Size { get { return 5; } }
    }
    class MockPosition : Position {
        public new int Size { get; set; }
    }
    ....
    var mock= new MockPosition();
    mock.Size = 7;
