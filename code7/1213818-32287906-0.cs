	var keyHandlers = new Dictionary<Keys, Action>(); 
	keyHandlers.Add(Keys.Back, () => Console.WriteLine("Handler for backspace"));
	keyHandlers.Add(Keys.Enter, () => {
		//some other statements, 
        //maybe set some class-level property 
		Console.WriteLine("Handler for enter ");
	});
    keyHandlers.Add(3, NameOfMethodThatMatchesActionDelegateSignature);
