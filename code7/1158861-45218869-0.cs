    public static Matrix<double> Sub(this Matrix<double> m, int[] rows, int[] columns)
    {
        var output = Matrix<double>.Build.Dense(rows.Length, columns.Length);
        for (int i = 0; i < rows.Length; i++)
        {
            for (int j = 0; j < columns.Length; j++)
            {
                output[i,j] = m[rows[i],columns[j]];
            }
        }
    
        return output;
    }
