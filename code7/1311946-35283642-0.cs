	static IEnumerable<TimeSample> TimeRollingWindow (IEnumerable<Data> data, TimeSpan interval)
	{
		
		
		Queue<Data> buffer = new Queue<Data>();
		
		foreach(var item in data) 
		{
			buffer.Enqueue(item);
            // Remove the old data
			while (buffer.Count > 0 && (item.Time - buffer.Peek().Time > interval))
			{
				buffer.Dequeue();
			}
			float max = float.MinValue;
			float min = float.MaxValue;
			double sum = 0;
			
            foreach(var h in buffer)
			{
				sum += h.Value;
				max = Math.Max(max, h.Value);
				min = Math.Min(min, h.Value);
			}
			// spit it out
			yield return new TimeSample(buffer.Peek().Time, item.Time, min, max, (float)(sum / buffer.Count));
		}
		
        if (buffer.Count > 0)
		{
			
			DateTime startTime = buffer.Peek().Time;
			DateTime endTime = startTime;
			int count = buffer.Count;
			float max = float.MinValue;
			float min = float.MaxValue;
			double sum = 0;
			while (buffer.Count > 0) 
			{
				var h = buffer.Dequeue();
				sum += h.Value;
				max = Math.Max(max, h.Value);
				min = Math.Min(min, h.Value);
				endTime = h.Time;
			}
			
			yield return new TimeSample(startTime, endTime, min, max, (float)(sum / count));
		}
		
	}
    class TimeSample 
	{
        public TimeSample(DateTime startTime, DateTime endTime,  float min, float max, float mean)
		{
			StartTime = startTime;
			EndTime = endTime;
			Min = min;
			Max = max;
			Mean = mean;
		}
		public readonly DateTime StartTime;
		public readonly DateTime EndTime;
		
		public readonly float Min;
		public readonly float Max;
		public readonly float Mean;
	}
	
	class Data
	{
		public Data(DateTime time, float value)
		{
			Time = time;
			Value = value;
		}
		public readonly DateTime Time;
		public readonly float Value;
	}
	
