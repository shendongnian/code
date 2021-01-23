        private void init(List<MatrixList> matricesMatrix)
        {
            MatrixList ml = new MatrixList();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    ml.matrixList.Add(new Matrix { row = i, column = j, value = i + j });
                }
            }
            matricesMatrix.Add(ml);
        }
