        private Dictionary<int, int> trialTypes;
		protected int GetTrialType(int trial)
		{
			try
			{
				return trialTypes[trial];
			}
			catch (Exception ex)
			{
				// your logging ...
			}
			return 0;
		}
        protected void AddTrialType(int trial, int type)
		{
			trialTypes.Add(trial, type);
		}
 
