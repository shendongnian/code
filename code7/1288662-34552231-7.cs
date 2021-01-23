    <Grid>
		<Grid.ColumnDefinitions>
			<ColumnDefinition Width="Auto"/>
			<ColumnDefinition />
		</Grid.ColumnDefinitions>
		<ListBox ItemsSource="{Binding AllStations.Keys}">
			<ListBox.ItemTemplate>
				<ItemContainerTemplate>
					<Button Command="{Binding Path=DataContext.RadialCommand, RelativeSource={RelativeSource AncestorType={x:Type ListBox}}}" CommandParameter="{Binding}">
						<TextBlock Text="{Binding}" />
					</Button>
				</ItemContainerTemplate>
			</ListBox.ItemTemplate>
		</ListBox>
		<ListView Grid.Column="1" ItemsSource="{Binding CurrentStations}" >
			<ListView.View>
				<GridView>
					<GridViewColumn Header="Nettstasjon" Width="100" DisplayMemberBinding="{Binding Path=Name}"/>
					<GridViewColumn Header="Område" Width="100" DisplayMemberBinding="{Binding Path=Area}"/>
					<GridViewColumn Header="Radial" Width="100" DisplayMemberBinding="{Binding Path=Radial}"/>
				</GridView>
			</ListView.View>
		</ListView>
	</Grid>
