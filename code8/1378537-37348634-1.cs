    				<DataGridTextColumn Header="Column 1 Data" Binding="{Binding Column1Data}" Width="Auto">
					<DataGridTextColumn.HeaderTemplate>
						<DataTemplate>
							<TextBlock Name="Header1TextBlock" Text="{TemplateBinding Content}" Tag="{Binding DataContext, ElementName=MyDataGrid}">
								<TextBlock.ContextMenu>
									<ContextMenu DataContext="{Binding Path=PlacementTarget.Tag, RelativeSource={RelativeSource Self}}">
										<CheckBox Name="Header1Checkbox" Content="Header Menu 1" IsChecked="{Binding Column1Checked, Mode=TwoWay}"/>
									</ContextMenu>
								</TextBlock.ContextMenu>
							</TextBlock>
						</DataTemplate>
					</DataGridTextColumn.HeaderTemplate>
				</DataGridTextColumn>
