    int rotatedDegrees; 
    int desiredRotation = 90;
    float startTime = null;
    float rotationDuration = 1f;
    public void rotate()
    {    
      if(startTime == null)
        startTime = time.Now;
      while((time.Now - starttime) / rotationDuration > (((float) rotatedDegrees) / desiredRotation))
      {
        transform.RotateAround (isolatedAxisPoint, Vector3.up, 1);
        rotatedDegrees++;
      }
    }
