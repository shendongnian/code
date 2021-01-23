	<ItemsControl ItemsSource="{Binding Records}">
		<ItemsControl.ItemTemplate>
			<DataTemplate>
				<Control>
					<Control.Resources>
						<ControlTemplate x:Key="StyleA">
							<TextBlock Text="Style A" />
						</ControlTemplate>
						<ControlTemplate x:Key="StyleB">
							<TextBlock Text="Style B" />
						</ControlTemplate>
					</Control.Resources>
					<Control.Style>
						<Style TargetType="{x:Type Control}">
							<Setter Property="Template" Value="{StaticResource StyleA}"/>
							<Style.Triggers>
								<DataTrigger Binding="{Binding Field}" Value="True">
									<Setter Property="Template" Value="{StaticResource StyleB}"/>
								</DataTrigger>
							</Style.Triggers>
						</Style>
					</Control.Style>
				</Control>
			</DataTemplate>
		</ItemsControl.ItemTemplate>
	</ItemsControl>
