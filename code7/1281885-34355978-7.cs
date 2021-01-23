    <DataGrid x:Name="customTasksDataGrid" ItemsSource="..." IsReadOnly="True" AutoGenerateColumns="False">
        <DataGrid.Columns>
            <DataGridTextColumn Header="ID" Binding="{Binding ID}"/>
		    <DataGridTextColumn Header="Klient" Binding="{Binding Name}">
				<DataGridTextColumn.ElementStyle>
					<Style TargetType="{x:Type TextBlock}">
						<Setter Property="ToolTipService.ToolTip">
							<Setter.Value>
								<TextBlock Text="{Binding Path=., Converter={StaticResource converter}}"/>
							</Setter.Value>
			    		</Setter>
					</Style>
				</DataGridTextColumn.ElementStyle>
			</DataGridTextColumn>
		</DataGrid.Columns>
	</DataGrid>
