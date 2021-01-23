	<DataGridTemplateColumn Header="Receiver">
		<DataGridTemplateColumn.CellTemplate>
			<DataTemplate>
				<ItemsControl ItemsSource="{Binding Item2}">
					<ItemsControl.ItemTemplate>
							<DataTemplate>
									<TextBlock Text="{Binding Device.Name, Mode=OneWay, UpdateSourceTrigger=PropertyChanged}" />
							</DataTemplate>
					</ItemsControl.ItemTemplate>
				</ItemsControl>
			</DataTemplate>
		</DataGridTemplateColumn.CellTemplate>
	</DataGridTemplateColumn>
