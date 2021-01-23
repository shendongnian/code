    using System.ComponentModel;
    namespace WpfApplication1
    {
        public sealed class Dot : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            internal Dot(double xPos, double yPos)
            {
                this.XPos = xPos;
                this.YPos = yPos;
            }
            public double XPos { get; }
            public double YPos { get; }
            #region IsOn
            // use a single event args instance
            private static readonly PropertyChangedEventArgs IsOnArgs =
                new PropertyChangedEventArgs(nameof(IsOn));
            private bool isOn;
            public bool IsOn
            {
                get
                {
                    return this.isOn;
                }
                set
                {
                    if (this.isOn == value)
                    {
                        return;
                    }
                    this.isOn = value;
                    this.PropertyChanged?.Invoke(this, IsOnArgs);
                }
            }
            #endregion IsOn
        }
    }
