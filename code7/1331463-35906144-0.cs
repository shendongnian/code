    private void Fire(){
		// Set the fired flag so only Fire is only called once.
		m_Fired = true;
		CmdCreateBullets ();
		// Change the clip to the firing clip and play it.
		m_ShootingAudio.clip = m_FireClip;
		m_ShootingAudio.Play ();
		// Reset the launch force.  This is a precaution in case of missing button events.
		m_CurrentLaunchForce = m_MinLaunchForce;
	}
	[Command]
	private void CmdCreateBullets()
    {
		RpclocalBullet ();
    }
	[ClientRpc]
	private void RpclocalBullet(){
		GameObject shellInstance = (GameObject)
			Instantiate (m_Shell, m_FireTransform.position, m_FireTransform.rotation) ;
		// Set the shell's velocity to the launch force in the fire position's forward direction.
		shellInstance.GetComponent<Rigidbody>().velocity = 25f * m_FireTransform.forward; 
	}
