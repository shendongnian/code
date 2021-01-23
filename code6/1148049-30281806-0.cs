	public ParticleSystem collisionParticlePrefab; //Assign the Particle from the Editor (You can do this from code too)
	private ParticleSystem tempCollisionParticle;
	void OnTriggerEnter (Collider _hit)
	{
		if (_hit.tag == "Coin") {
			Destroy (_hit.gameObject);
			coinCount++;
			coinsText.text = "Coins: " + coinCount.ToString() + "/" + coinTotal.ToString();
			tempCollisionParticle = Instantiate (collisionParticlePrefab, transform.position, Quaternion.identity) as ParticleSystem;
			tempCollisionParticle.Play ();
		}
	}
