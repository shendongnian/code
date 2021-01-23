	<UserControl.Resources>
        <ResourceDictionary>
            <local:ColorBeginDateConverter x:Key="beginDate" />
        </ResourceDictionary>
    </UserControl.Resources>
    <Grid>		
		<DataGrid Name="gridEmployees" ItemsSource="{Binding Employees}" AutoGenerateColumns="False">
            <DataGrid.Columns>
                <DataGridTextColumn Header="BeginDate" Binding="{Binding BeginDate}">
                    <DataGridTextColumn.CellStyle>
                        <Style TargetType="DataGridCell">
                            <Setter Property="Background" Value="{Binding BeginDate, Converter={StaticResource beginDate} }" />
                        </Style>
                    </DataGridTextColumn.CellStyle>
                </DataGridTextColumn>
            </DataGrid.Columns>
        </DataGrid>
	</Grid>
	
