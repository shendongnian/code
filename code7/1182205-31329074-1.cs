	void Main()
	{
		var boss = new BossBehaviour();
		boss.Damage(0.1f);
		boss.Update();
		boss.Damage(0.3f);
		boss.Update();
		boss.Damage(0.15f);
		boss.Update();
		boss.Update();
		boss.Damage(0.4f);
		boss.Update();
	}
	class BossBehaviour {
		float _currentHealth = 1.0f;
		float _healthFromLastUpdate = 1.0f;
		public void Update(){
			Console.WriteLine("Updating. Current health: {0}", _currentHealth);
			
			if (WasThresholdPassed(0.75f)){
				SpawnMinions();
			}
			
			if (WasThresholdPassed(0.5f)) {
				SpawnMinions();
			}
			
			if (WasThresholdPassed(0.25f)) {
				SpawnMinions();
			}
			
			_healthFromLastUpdate = _currentHealth;
		}
		bool WasThresholdPassed(float threshold) {
			if (_healthFromLastUpdate < threshold) 
				return false;
			if (_currentHealth < threshold)
				return true;
			return false;
		}
		void SpawnMinions() {
			/* ... */
			Console.WriteLine("> Spawning minions. Current health: {0}", _currentHealth);
		}
		public void Damage(float percentDamage) {
			_currentHealth -= percentDamage;
		}
	}
