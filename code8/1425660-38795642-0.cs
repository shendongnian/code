    public class Example
    {
        private readonly Car _car;
        public Example(Car car)
        {
            _car = car;
            _car.PropertyChanged += HandleA;
            _car.PropertyChanged += HandleD;
            _car.PropertyChanged += HandleG;
        }
    
        private void HandleA(object sender, PropertyChangedEventArgs args)
        {
            if(args.PropertyName == "A" || String.IsNullOrEmpty(args.PropertyName))
            {
                //Do logic for A
            }
        }
    
        private void HandleD(object sender, PropertyChangedEventArgs args)
        {
            if(args.PropertyName == "D" || String.IsNullOrEmpty(args.PropertyName))
            {
                //Do logic for D
            }
        }
    
        private void HandleG(object sender, PropertyChangedEventArgs args)
        {
            if(args.PropertyName == "G" || String.IsNullOrEmpty(args.PropertyName))
            {
                //Do logic for G
            }
        }
    }
