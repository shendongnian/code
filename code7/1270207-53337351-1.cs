    public class BooleanToGridLengthConverter : BooleanConverter<System.Windows.GridLength>
    {
       public BooleanToGridLengthConverter() : base(
         new System.Windows.GridLength(1, System.Windows.GridUnitType.Star),
         new System.Windows.GridLength(0))
       {
       }
    }
