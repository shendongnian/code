    using NiftyStuff;
    using static NiftyStuff.With;
    //...
        with ((Enemy e) => {
		    if (e.Damage(50)) {
			    Log("Made a kill!"); // Whatever log function you have...
    		}
	    });
	    with ((Pumpkin p) => {
		    if (p.LookAt()) {
			    Log("You see the pumpkin");
		    } else {
			    Log("You no longer see the pumpkin");
		    }
	    });
