    <Style.Triggers>
		<Trigger Property="Background" Value="Red">
			<Trigger.EnterActions>
				<BeginStoryboard Name="flash" Storyboard="{StaticResource flashAnimation}" />
			</Trigger.EnterActions>
		</Trigger>
	</Style.Triggers>
