	<Button Width="150" >
		<Button.Template>
			<ControlTemplate TargetType="{x:Type Button}">
				<ControlTemplate.Resources>
					<Storyboard x:Key="MouseOverAnimation">
						<ThicknessAnimation Storyboard.TargetName="ButtonBorder" Storyboard.TargetProperty="BorderThickness" To="3" Duration="0:0:0.2" />
					</Storyboard>
					<Storyboard x:Key="MouseOutAnimation">
						<ThicknessAnimation Storyboard.TargetName="ButtonBorder" Storyboard.TargetProperty="BorderThickness" To="1" Duration="0:0:0.2" />
					</Storyboard>
				</ControlTemplate.Resources>
				<Grid>
					<Border x:Name="ButtonBorder" BorderThickness="{TemplateBinding BorderThickness}" BorderBrush="{TemplateBinding BorderBrush}">
						<VirtualizingStackPanel   VirtualizingPanel.IsVirtualizing="True" VirtualizingPanel.VirtualizationMode="Recycling" Background="{TemplateBinding Background}">
						</VirtualizingStackPanel>
					</Border>
					<ContentPresenter VerticalAlignment="Center" HorizontalAlignment="Center"/>
				</Grid>
				<ControlTemplate.Triggers>
					<Trigger Property="IsMouseOver" Value="True">
						<Trigger.EnterActions>
							<BeginStoryboard Storyboard="{StaticResource MouseOverAnimation}"></BeginStoryboard>
						</Trigger.EnterActions>
						<Trigger.ExitActions>
							<BeginStoryboard Storyboard="{StaticResource MouseOutAnimation}"></BeginStoryboard>
						</Trigger.ExitActions>
					</Trigger>
				</ControlTemplate.Triggers>
			</ControlTemplate>
		</Button.Template>
		<TextBlock FontSize="20" Foreground="Green">INSTALL</TextBlock>
	</Button>
