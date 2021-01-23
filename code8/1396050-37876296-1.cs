    public class Stepper : ISensorEventListener, INameOfDependencyInterface
    {
    
        private Action<float> _stepCountChanged;
    
        public static void Init(Action<float> stepCountChanged)
        {
            SensorManager senMgr = (SensorManager)GetSystemService(SensorService);
            Sensor counter = senMgr.GetDefaultSensor(SensorType.StepCounter);
    
            if (counter != null)
            {
                senMgr.RegisterListener(this, counter, SensorDelay.Normal);
            }
    
            _stepCountChanged = stepCountChanged;
        }
        public void OnSensorChanged(SensorEvent e)
        {
            _stepCountChanged(e.Values.First());
    
        }
    }
