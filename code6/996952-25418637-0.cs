    float smooth;
	float smooth1;
    void Start () {
		
		smooth = PlaneMovement.GameSpeed;
		smooth1 = PlaneMovement.GameSpeed;
	}
    PlaneMovement.GameSpeed = Mathf.Lerp (PlaneMovement.GameSpeed,smooth,Time.deltaTime);
		if(SpeedUp){
			SpeedUpTimer -= Time.deltaTime;
			if(SpeedUpTimer <= 0){
				SpeedUp = false;
				smooth = smooth1;
			}
