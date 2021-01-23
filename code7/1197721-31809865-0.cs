    Image image = new Image ();
    image.Triggers.Add(new Trigger(typeof(Image)) {
    	Property = Image.SourceProperty,
    	EnterActions = {
    		new FadeTriggerAction() {
    			StartsFrom = 1
    		}
    	},
    	ExitActions = {
    		new FadeTriggerAction() {
    			StartsFrom = 0
    		}
    	}
    });
