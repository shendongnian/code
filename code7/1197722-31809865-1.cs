    public class FadeTriggerAction : TriggerAction<VisualElement>
    {
    	public FadeTriggerAction() {}
    
    	public int StartsFrom { set; get; }
    
    	protected override void Invoke (VisualElement visual)
    	{
    		visual.Animate("", new Animation( (d)=>{
    			var val = StartsFrom == 0 ? d : 1-d;
    			visual.Opacity = val;
    
    		}),
    			length:1000, // milliseconds
    			easing: Easing.Linear);
    	}
    }
