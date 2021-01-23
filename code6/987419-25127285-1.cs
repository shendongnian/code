	<ItemsControl ItemsSource="{Binding ResearchLanguageViewModel.Filters, Mode=OneWay}">
		<ItemsControl.ItemTemplate>
			<DataTemplate>
				<StackPanel>
					<TextBlock Text="{Binding Path=Type}"></TextBlock>
					<TextBox Text="Search...."></TextBox>
					<ItemsControl>
						<ItemsControl.ItemTemplate ItemsSource={Binding Path=Values}>
							<DataTemplate>								
								<CheckBox Content="{Binding Mode=TwoWay}"></CheckBox>
							</DataTemplate>
						</ItemsControl.ItemTemplate>
					</ItemsControl>
				</StackPanel>
			</DataTemplate>
		</ItemsControl.ItemTemplate>
	</ItemsControl>
