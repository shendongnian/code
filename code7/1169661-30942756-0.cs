	<DataGrid x:Name="dg" Margin="10,32,10,111" AlternatingRowBackground="White" SelectionChanged="dgDailyMediaReport_SelectionChanged" IsReadOnly="True" AutoGenerateColumns="False" SelectionMode="Single" >
		<DataGrid.Columns>
			<DataGridTemplateColumn Header="{Binding Status}" Width="75">
				<DataGridTemplateColumn.CellTemplate>
					<DataTemplate>
						<Grid>
							<ProgressBar  Height="20"  Grid.Row="0" Grid.Column="0" Minimum="0" Maximum="500" Value="{Binding TotalProgress, Mode=OneWay}"></ProgressBar>
							<Label HorizontalAlignment="Center" Content="{Binding TotalPercent,Mode=OneWay}"></Label>
						</Grid>
					</DataTemplate>
				</DataGridTemplateColumn.CellTemplate>
			</DataGridTemplateColumn>
			<DataGridTextColumn Header="NAME" Binding="{Binding Name}" Foreground="DarkRed" />
			<DataGridTextColumn Header="AGE" Binding="{Binding Age}" />
			
		</DataGrid.Columns>
		<DataGrid.ContextMenu>
			<ContextMenu>
				<MenuItem x:Name="menuShowInFolder" Header="Show In Folder" Click="menuShowInFolder_Click"/>
			</ContextMenu>
		</DataGrid.ContextMenu>
	</DataGrid>
