	<DataGrid Grid.Row="1" ItemsSource="{Binding ViewModels}" CanUserAddRows="False" CanUserDeleteRows="False" CanUserReorderColumns="False" CanUserResizeColumns="False"
	  CanUserResizeRows="False" CanUserSortColumns="False" AutoGenerateColumns="False" HeadersVisibility="Column">
		<DataGrid.Columns>
			<DataGridTemplateColumn Header="HeaderName" >
				<DataGridTemplateColumn.CellTemplate>
					<DataTemplate>
						<TextBlock Text="{Binding Symbol}" />
					</DataTemplate>
				</DataGridTemplateColumn.CellTemplate>
				<DataGridTemplateColumn.CellStyle>
					<Style TargetType="{x:Type DataGridCell}">
						<Style.Triggers>
							<DataTrigger Binding="{Binding IsExpired}" Value="True">
								<Setter Property="BorderBrush" Value="Red"/>
							</DataTrigger>
						</Style.Triggers>
					</Style>
				</DataGridTemplateColumn.CellStyle>
			</DataGridTemplateColumn>
		</DataGrid.Columns>
        <!-- ... -->
	</DataGrid>
