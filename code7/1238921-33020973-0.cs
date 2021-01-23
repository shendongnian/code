	<ItemsControl ItemsSource="{Binding SellTransactions}">
		<ItemsControl.ItemsPanel>
			<ItemsPanelTemplate>
				<StackPanel />
			</ItemsPanelTemplate>
		</ItemsControl.ItemsPanel>
		<ItemsControl.ItemTemplate>
			<DataTemplate>
				<Grid>
					<Grid.ColumnDefinitions>
						<ColumnDefinition></ColumnDefinition>
						<ColumnDefinition></ColumnDefinition>
						<ColumnDefinition></ColumnDefinition>
						<ColumnDefinition></ColumnDefinition>
						<ColumnDefinition></ColumnDefinition>
						<ColumnDefinition></ColumnDefinition>
					</Grid.ColumnDefinitions>
					<Label Grid.Column="0" Content="{Binding created}"></Label>
					<Label Grid.Column="1" Content="{Binding id}"></Label>
					<Label Grid.Column="2" Content="{Binding item_id}"></Label>
					<Label Grid.Column="3" Content="{Binding price}"></Label>
					<Label Grid.Column="4" Content="{Binding purchased}"></Label>
					<Label Grid.Column="5" Content="{Binding quantity}"></Label>
				</Grid>
			</DataTemplate>
		</ItemsControl.ItemTemplate>
	</ItemsControl>
