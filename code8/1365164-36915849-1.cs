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
        float finalTotal;
  
        for(int i = 0; i < speeds.Count; i++)
        {
             averageTotal += speeds[i]
        }
        finalTotal = averageTotal / speeds.Count;
        speeds.Clear() // so as the list is free for the next time
        return finalTotal;
    }
