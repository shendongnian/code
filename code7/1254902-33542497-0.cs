    <EventTrigger RoutedEvent="Button.Click">
    	<EventTrigger.EnterActions>
    		<BeginStoryboard>
    			<Storyboard>
    				<BooleanAnimationUsingKeyFrames Storyboard.TargetProperty="IsEnabled" FillBehavior="HoldEnd">
    					<DiscreteBooleanKeyFrame KeyTime="00:00:00" Value="False" />
    	   		    </BooleanAnimationUsingKeyFrames>
    			</Storyboard>
   			</BeginStoryboard>
   		</EventTrigger.EnterActions>
   		<EventTrigger.ExitActions>
   			<BeginStoryboard>
   				<Storyboard>
   					<BooleanAnimationUsingKeyFrames Storyboard.TargetProperty="IsEnabled" FillBehavior="HoldEnd">
   						<DiscreteBooleanKeyFrame KeyTime="00:00:00" Value="True" />
   					</BooleanAnimationUsingKeyFrames>
   				</Storyboard>
   			</BeginStoryboard>
   		</EventTrigger.ExitActions>
   	</EventTrigger>
