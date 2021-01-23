    [TestMethod]
    public void SubmitBowlingScore()
    {
        //Arrange
        var frames = new Frame[]
        {
                new Frame {FirstRoll = 2, SecondRoll = 2, ThirdRoll = 0},
                new Frame {FirstRoll = 2, SecondRoll = 6, ThirdRoll = 0},
                new Frame {FirstRoll = 0, SecondRoll = 9, ThirdRoll = 0}
        };
        //Act
        var score = frames.SumFrameScores();
        //Assert
        Assert.AreEqual(21, score);
    }
