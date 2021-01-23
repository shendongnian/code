    public abstract class Evd<T> : ISolver<T>
    where T : struct, IEquatable<T>, IFormattable
    {
        /// <summary>
        /// Gets or sets the eigen values (λ) of matrix in ascending value.
        /// </summary>
        public Vector<Complex> EigenValues { get; private set; }
        
        /// <summary>
        /// Gets or sets eigenvectors.
        /// </summary>
        public Matrix<T> EigenVectors { get; private set; }
    }
