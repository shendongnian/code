    	// Create new SoundPlayer in the using statement.
    	using (SoundPlayer player = new SoundPlayer())
    	{
          for (int i = 0; i <= music.Count - 1; i++)
               {
                   string text = music[i].pitch.ToString();
                   sp.SoundLocation = (@"c:\my path here\" + text + ".wav");
                   // Use PlaySync to load and then play the sound.
    	           // ... The program will pause until the sound is complete.
    	           player.PlaySync();
               }
    	}
