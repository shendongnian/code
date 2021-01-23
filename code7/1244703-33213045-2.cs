    private Storyboard ButtonStoryboard { get; set; }
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
    	if (this.ButtonStoryboard == null)
    	{
    		string[] names ={"/Assets/1.png", "/Assets/2.png", "/Assets/3.png", "/Assets/4.png", "/Assets/5.png" };
    
    		var storyboard = new Storyboard();
    		var animation = new ObjectAnimationUsingKeyFrames();
    
    		Storyboard.SetTarget(animation,img);
    		Storyboard.SetTargetProperty(animation, new PropertyPath("Source"));
    
    		storyboard.Children.Add(animation);
    
    		for (int i=0 ; i <=4; i++)
    		{
    			var keyframe = new DiscreteObjectKeyFrame
    			{
    				KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(300* i)),
    			   Value = String.Format(names[i])
    			};
    
    			animation.KeyFrames.Add(keyframe);
    		}
    		
    		this.ButtonStoryboard = storyboard;
    	}
    
    	if (this.ButtonStoryboard.GetCurrentState() != ClockState.Stopped)
    	{
    		this.ButtonStoryboard.Stop();
    		this.ButtonStoryboard.Seek(TimeSpan.Zero);
    	}
    
    	this.ButtonStoryboard.Begin();
    }
