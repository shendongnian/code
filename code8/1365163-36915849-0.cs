    List<float> speeds = new List<float>()
    void CalculateSpeed()
    {
        speed = lastDistance / lastTime * 3.6f;
        speedText.text = Mathf.RoundToInt(speed).ToString();
        List.Add(speed);
    }
    void float returnAverage() //call when Finished
    {
        float averageTotal;
  
        for(int i = 0; i < speeds.Count; i++)
        {
             averageTotal += speeds[i]
        }
        return averageTotal / speeds.Count;
    }
