	public class MurderEventArgs : EventArgs
	{
		public MurderEventArgs(IPerson victim, IPerson murderer)
		{
			Victim = victim;
			Murderer = murderer;
		}
		public IPerson Victim { get; }
		public IPerson Murderer { get; }
	}
