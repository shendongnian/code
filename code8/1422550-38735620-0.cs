    <Grid.Resources>
		<Storyboard x:Name="storyboardbtnNextKitty">
			<DoubleAnimation Storyboard.TargetName="btnNextKitty" Storyboard.TargetProperty="(UIElement.RenderTransform).(CompositeTransform.TranslateX)" From="1000" To="0"  Duration="0:0:0.5">
				<DoubleAnimation.EasingFunction>
					<CubicEase EasingMode="EaseOut"/>
				</DoubleAnimation.EasingFunction>
			</DoubleAnimation>
		</Storyboard>
	</Grid.Resources>
