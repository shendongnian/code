	<ItemsControl ItemsSource="{Binding myCollection}" >
		<ItemsControl.Resources>
			<DataTemplate DataType="{x:Type local:myViewModelForItemA}">
				<CheckBox IsChecked="{Binding IsChecked}" Content="{Binding aName}"></CheckBox>
			</DataTemplate>
			<DataTemplate DataType="{x:Type local:myViewModelForItemB}">
				<RadioButton IsChecked="{Binding IsChecked}" Content="{Binding aName}"></RadioButton>
			</DataTemplate>
		</ItemsControl.Resources>
	</ItemsControl>
