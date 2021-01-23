    [TestMethod]
    public void MatrixMultiplication_IncorrectMatrixSize_ExceptionTest()
    {
        // Arrange
        var elementsA = new float[,]
        {
            {4, 7},
            {6, 8}
        };
    
        var elementsB = new float[,]
        {
            {3, 0},
            {1, 1},
            {5, 2}
        };
    
        Matrix A = new Matrix() {Rows=2, Columns=2, Elements=elementsA);
        Matrix B = new Matrix() {Rows=3, Columns=2, Elements=elementsB);
    
        // Act
        Action act = () => { var x = A * B; };
    
        // Assert
        act.ShouldThrow<Exception>().WithMessage("These matrices cant be multiplied");
    }
