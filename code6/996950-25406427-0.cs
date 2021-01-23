    PlaneMovement.GameSpeed = Mathf.Lerp (PlaneMovement.GameSpeed,smooth,Time.time);
    if(SpeedUp){
      SpeedUpTimer -= Time.deltaTime;
      print(SpeedUpTimer);
      if(SpeedUpTimer <= 0){
        SpeedUp = false;
        smooth = PlaneMovement.GameSpeed;
      }
    }
