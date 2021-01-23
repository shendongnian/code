		private long _pressedTicks;
		private long _durationTicks;
		private bool _pressed;
		public bool Pressed
		{
			get { return _pressed; }
			set
			{
				if (value == _pressed)
				{
					//Do nothing;
				}
				else if (value == false)
				{
					_durationTicks = DateTime.Now.Ticks - _pressedTicks;
					_pressed = value;
				}
				else
				{
					_pressed = value;
					_pressedTicks = DateTime.Now.Ticks;
                }
			}
		}
