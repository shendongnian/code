    <DataGridCheckBoxColumn Header="Add" Width="75" Binding="{Binding Buy}">
    	**<DataGridCheckBoxColumn.CellStyle>
    		<Style TargetType="DataGridCell">
    			<Style.Triggers>
    				<DataTrigger Binding="{Binding Path=YourPropertyName}" Value="False">
    					<Setter Property="IsEnabled" Value="False" />
    				</DataTrigger>
    			</Style.Triggers>
    		</Style>
    	</DataGridCheckBoxColumn.CellStyle>**	
        <DataGridCheckBoxColumn.HeaderStyle>
                        <Style TargetType="DataGridColumnHeader">
                            <Setter Property="HorizontalContentAlignment" Value="Center" />
                        </Style>
                    </DataGridCheckBoxColumn.HeaderStyle>
    	</DataGridCheckBoxColumn>
    	<DataGridCheckBoxColumn Header="Remove" Width="75"  Binding="{Binding Rent}">
            <DataGridCheckBoxColumn.HeaderStyle>
                <Style TargetType="DataGridColumnHeader">
                    <Setter Property="HorizontalContentAlignment" Value="Center" />
                </Style>
            </DataGridCheckBoxColumn.HeaderStyle>
    </DataGridCheckBoxColumn>
