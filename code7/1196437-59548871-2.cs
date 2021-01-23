    public class ComplexEqualConstraint
        : EqualConstraint
    {
        public ComplexEqualConstraint(EqualConstraint that)
            : base(that)
        {
        }
        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            bool success = false;
            if (actual is Complex z1)
            {
                Complex z2 = (Complex)this.Arguments[0];
                success = Math.Abs(z1.Real - z1.Real) < Tolerance.Real &&
                          Math.Abs(z1.Imaginary - z2.Imaginary) < Tolerance.Imaginary;
            }
            return new ConstraintResult(this, actual, success);
        }
        public new Complex Tolerance
        {
            get;
            set;
        } = Complex.Zero;
    }
