    public class SpeedHolder
    {
        private float _speed;
        public event Action<float> OnSpeedChange;
        public float Speed
        {
            get { return _speed; }
            set { SetSpeed(value); }
        }
        public SetSpeed(float value)
        {
            _speed = value;
            if(OnSpeedChange != null)
                OnSpeedChange(_speed);
        }
    }
