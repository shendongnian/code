    /// <summary>
    /// Stores Vector3 samples such as velocity or position and returns the average.
    /// </summary>
    [Serializable]
    public class Vector3Buffer
    {
    	public readonly int size;
    
    	Sample[] sampleData;
    	int nextIndex;
    
    	public Vector3Buffer(int size)
    	{
    		if (size < minSize)
    		{
    			size = minSize;
    			Debug.LogWarning("Sample count must be at least one. Using default.");
    		}
    
    		this.size = size;
    		sampleData = new Sample[size];
    	}
    
    	public void AddSample(Vector3 position, float deltaTime)
    	{
    		sampleData[nextIndex] = new Sample(position, deltaTime);
    		nextIndex = ++nextIndex % size;
    	}
    
    	public void Clear()
    	{
    		for (int i = 0; i < size; i++)
    			sampleData[i] = new Sample();
    	}
    
    	public Vector3 GetAverageVelocity(Vector3 currentPosition, float currentDeltaTime)
    	{
    		// The recorded sample furthest back in time.
    		Sample previous = sampleData[nextIndex % size];
    		Vector3 positionDelta = currentPosition - previous.position;
    		float totalTime = currentDeltaTime;
    		for (int i = 0; i < size; i++)
    			totalTime += sampleData[i].deltaTime;
    
    		return positionDelta / totalTime;
    	}
    
    	[Serializable]
    	struct Sample
    	{
    		public Vector3 position;
    		public float deltaTime;
    
    		public Sample(Vector3 position, float deltaTime)
    		{
    			this.position = position;
    			this.deltaTime = deltaTime;
    		}
    	}
    
    	public const int minSize = 1;
    }
