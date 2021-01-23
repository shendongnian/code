    class Holm : ModelBase
    {
        public Holm(String Name, TestSensor sensor1, TestSensor sensor2)
        {
            Sensor1 = sensor1;
            Sensor2 = sensor2;
            this.Name = Name;
            Sensor1.PropertyChanged += OnSensorOnlineChanged;
            Sensor1.PropertyChanged += OnSensorOnlineChanged;
        }
        private void OnSensorOnlineChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsOnline")
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(nameof(IsOnline)));
            }
        }
    }
