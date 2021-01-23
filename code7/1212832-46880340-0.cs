    public static Matrix<double> GetCovarianceMatrix(Matrix<double> matrix)
    {
        var columnAverages = matrix.ColumnSums() / matrix.ColumnCount;
        var centeredColumns = matrix.EnumerateColumns().Zip(columnAverages, (col, avg) => col - avg);
        var centered = DenseMatrix.OfColumnVectors(centeredColumns);
        var normalizationFactor = matrix.RowCount == 1 ? 1 : matrix.RowCount - 1;
        return centered.TransposeThisAndMultiply(centered) / normalizationFactor;
    }
