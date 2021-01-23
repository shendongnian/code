        bool runningOnBattleUpdate = false;
        public void OnBattleUpdate(object sender, ElapsedEventArgs e)
        {
            if (runningOnBattleUpdate) return;
            try
            {
                runningOnBattleUpdate = true;
                if (monster.IsAlive == false)
                {
					// Stuff
                }
                else
                {
					// Other stuff
                }
            }
            finally
            {
                runningOnBattleUpdate = false;
            }
        }
		
