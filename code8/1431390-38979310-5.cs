	npc.OnMurderEvent += Npc_OnMurderEvent;
	npc.RaiseMurderEvent(victim, murderer);
    private static void Npc_OnMurderEvent(object sender, MurderEventArgs e)
	{
		Console.WriteLine(e.Victim.Name + " was murdered by " + e.Murderer.Name);
		var murdererAsChild = e.Murderer as Child;
		if (murdererAsChild != null)
			Console.WriteLine(".. who is only a child, it must be Damien!");
			
		// Deal with any other special cases for particular Victim, Murderer combinations..
	}
