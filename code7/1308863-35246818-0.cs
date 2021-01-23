        private float[] mGravity;
        private float[] mGeomagnetic;
        public void OnSensorChanged(SensorEvent e)
        {
            if (e.Sensor.Type == SensorType.Accelerometer)
                this.mGravity = e.Values.ToArray();
            if (e.Sensor.Type == SensorType.MagneticField)
                this.mGeomagnetic = e.Values.ToArray();
            if (this.mGravity != null && this.mGeomagnetic != null)
            {
                float[] R = new float[9];
                float[] I = new float[9];
                bool success = SensorManager.GetRotationMatrix(R, I, this.mGravity, this.mGeomagnetic);
                if (success)
                {
                    var orientation = new float[3];
                    SensorManager.GetOrientation(R, orientation);
                    var rotation = new Vector3(orientation[0], orientation[1], orientation[2]);
                    this.ReadingReceived?.Invoke(this, rotation);
                }
            }
        }
