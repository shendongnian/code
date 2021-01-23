	[Player Controller Script]
	public Gun gun;
	 void Update() 
	 {
		ControlMouse();
		if (Input.GetButtonDown("Shoot"))
		{
			if (gun.gunType == Gun.GunType.Explosive)
			{
				gun.ShootExplosive();
			}
			else if (gun.gunType == Gun.GunType.Auto)
			{
				gun.ShootContinuous();
			} 
			else 
			{ 
				gun.Shoot(); 
			}
		}
	}
