	pubic class Player
	{
		private Level _level;
		
		public Level Level 
		{ 
			get { return _level; }
			set { _level = value; }
		}
        // Or auto-implemented property
        public Level Level { get; set; }
		public Player()
		{        
		}
	}
