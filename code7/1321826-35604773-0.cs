    public partial class MyProgressBar : ProgressBar
    {
            public new int Value
            {
                get { return base.Value; }
                set
                {
                    if (value < Minimum) value = Minimum;
                    if (value > Maximum) value = Maximum;
                    base.Value = value;
                }
            }
    }
