<b>1)</b> The Draw function is meant for drawing. It's running (kind of) async from the game. All your game logic should be in the Update function.<br>
<b>2)</b> You have to know how to check if a keyboard button is clicked, not if it is being held down, because this way, the character will Load as long as you are holding the 'T' key. No matter how fast you click 'T' key, the way you are doing it, you'll fire the Load function at least 2-3 times.<br>
<b>3)</b> To check this, you'll need 2 variables holding the current and the last state of keyboard, and all your game logic should be in between the updates for new and old keyboard state. You could also create a simple function to check for Click(Keys key) and Hold(Keys key)
	KeyboardSate ksNew, ksOld;
    protected override void Update (GameTime gameTime)
	{
		ksNew = KeyboardSate.GetState();
		
		*your logic here*
		if (Click(Keys.T))
            player.Load(Content);
		
		ksOld = ksNew;
	}
	
	private bool Click(Keys key)
	{
		return ksNew.IsKeyDown(key) && ksOld.IsKeyUp(key);
	}
	
	private bool Hold(Keys key)
	{
		return ksNew.IsKeyDown(key);
	}
