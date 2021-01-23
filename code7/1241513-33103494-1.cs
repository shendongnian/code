        public void AddDataPoint(int angle, int amplitude)
        {
            try
            {
                var dataPoint = Data.FirstOrDefault(d => d.PhaseAngle == angle && d.Amplitude == amplitude);
                if (dataPoint != null)
                {
                    dataPoint.Count++;
                }
                else
                {
                    Data.Add(new EventDataPointsViewModel { Amplitude = amplitude, PhaseAngle = angle, Count = 1 });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
