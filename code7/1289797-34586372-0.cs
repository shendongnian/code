    [Test]
    public void BoardCreationTest()
    {
        var board = CreateBoard();
        
        //Calling method explicitly makes test more readable
        board.Reset();
        for (int i = 0; i < board.Height; i++)
        {
            for (int j = 0; j < board.Width; j++)
            {
               Assert.IsTrue(board.IsMoveValid(i, j, 1));
            }
        }
    }
    private IBoard CreateBoard()
    {
        var cellFactory = Substitute.For<ICellFactory>();
        //You may replace Cell with another mock or smth else. Depends on your assert section.
        cellFactory.Create(Arg.Any<int>(), Arg.Any<int>())
           .Returns(x => new Cell((int)x[0], (int)x[1]))        
        IBoard board = new Board(3, 3, cellFactory);
    } 
