    class Car : INotifyPropertyChanged
    {
        private bool buy, rent;
        public bool Buy 
        {
            get { return buy; }
            set { SetAndNotifyIfChanged(ref buy, value); }
        }
        public bool Rent 
        {
            get { return rent; }
            set { SetAndNotifyIfChanged(ref rent, value); }
        }
        public string Name { get; set; }
        public Car(string name, bool isBuy)
        {
            Name = name;
            buy = isBuy;
            rent = !isBuy;
        }
        private void SetAndNotifyIfChanged<T>(ref T original, T newValue, [CallerMemberName] string caller = null)
            where T : IEquatable<T>
        {
            if (!original.Equals(newValue))
            {
                original = newValue;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
