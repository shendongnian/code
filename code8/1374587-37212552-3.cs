    int rotatedDegrees; 
    int desiredRotation = 90;
    float startTime = null;
    float rotationDuration = 1f;
    public void rotate()
    {    
      if(startTime == null)
        startTime = time.now;
      while((time.now - starttime) / rotationDuration > (((float) rotatedDegress) / desiredRotation))
      {
        transform.RotateAround (isolatedAxisPoint, Vector3.up, 1);
      rotatedDegrees++;
      }
    }
