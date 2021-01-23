    public struct Matrix
    {
        private bool determinantEvaluated;
        private double determinant;
        public double Determinant
        {
            get
            {
                if (!determinantEvaluated)
                {
                    determinant = 1.0;
                    determinantEvaluated = true;
                }
                return determinant;
            }
        }
    }
