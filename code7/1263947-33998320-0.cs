    <Grid x:Name="Overlay" Panel.ZIndex="2" Grid.Row="1">
			<Grid.Background>
				<SolidColorBrush Color="Black" Opacity=".3"/>
			</Grid.Background>
			<Grid.Style>
				<Style TargetType="Grid">
					<Setter Property="Visibility" Value="Collapsed"/>
					<Style.Triggers>
						<DataTrigger Binding="{Binding IsChecked, ElementName=FiltersButton}" Value="True">
							<Setter Property="Visibility" Value="Visible"/>
						</DataTrigger>
					</Style.Triggers>
				</Style>
			</Grid.Style>
			<Grid.Triggers>
				<EventTrigger RoutedEvent="UIElement.MouseDown">
					<EventTrigger.Actions>
						<BeginStoryboard>
							<Storyboard>
								<BooleanAnimationUsingKeyFrames Storyboard.TargetName="FiltersButton" Storyboard.TargetProperty="(ToggleButton.IsChecked)">
									<DiscreteBooleanKeyFrame KeyTime="0:0:00.0" Value="False" />
								</BooleanAnimationUsingKeyFrames>
							</Storyboard>
						</BeginStoryboard>
					</EventTrigger.Actions>
				</EventTrigger>
			</Grid.Triggers>
		</Grid>
