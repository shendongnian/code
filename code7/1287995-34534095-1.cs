    private double _ScaleX;
        public double ScaleX
        {
            get { return _ScaleX; }
            set { _ScaleX = value; NotifyPropertyChanged(); }
        }
        private double _ScaleY;
        public double ScaleY
        {
            get { return _ScaleY; }
            set { _ScaleY = value; NotifyPropertyChanged(); }
        }
        private double _RotateAngle;
        public double RotateAngle {
            get { return _RotateAngle; }
            set { _RotateAngle = value; NotifyPropertyChanged(); }
        }
        private double _MouseX;
        public double MouseX
        {
            get { return _MouseX; }
            set { _MouseX = value; NotifyPropertyChanged(); }
        }
        private double _MouseY;
        public double MouseY
        {
            get { return _MouseY; }
            set { _MouseY = value; NotifyPropertyChanged(); }
        }
        public bool IsMouseCaptured { get; set; }
        private RelayCommand _mouseDownCommand;
        public RelayCommand MDCommand
        {
            get
            {
                if (_mouseDownCommand == null) return _mouseDownCommand = new RelayCommand(param => ExecuteMouseDown((MouseEventArgs)param));
                return _mouseDownCommand;
            }
            set { _mouseDownCommand = value; }
        }
        System.Windows.Point start;
        System.Windows.Point origin;
        private void ExecuteMouseDown(MouseEventArgs e)
        {
            var image = (System.Windows.Controls.Image)e.OriginalSource;
            var border = (IInputElement)image.Parent;
            start = e.GetPosition(border);
            origin = new System.Windows.Point(MouseX, MouseY);
            IsMouseCaptured = true;
            
        }
        private RelayCommand _mouseMoveCommand;
        public RelayCommand MMCommand
        {
            get
            {
                if (_mouseMoveCommand == null) return _mouseMoveCommand = new RelayCommand(param => ExecuteMouseMove((MouseEventArgs)param));
                return _mouseMoveCommand;
            }
            set { _mouseMoveCommand = value; }
        }
        private void ExecuteMouseMove(MouseEventArgs e)
        {
           
            if(IsMouseCaptured)
            {
                var image = (System.Windows.Controls.Image)e.OriginalSource;
                var border = (IInputElement)image.Parent;
                Vector v = start - e.GetPosition(border);
                MouseX = origin.X - v.X;
                MouseY = origin.Y - v.Y;
            }
        }
        private RelayCommand _MLBUCommand;
        public RelayCommand MLBUCommand
        {
            get
            {
                if (_MLBUCommand == null) return _MLBUCommand = new RelayCommand(param => Execute_MLBU((MouseEventArgs)param));
                return _MLBUCommand;
            }
            set { _MLBUCommand = value; }
        }
        private void Execute_MLBU(MouseEventArgs param)
        {
            IsMouseCaptured = false;
        }
