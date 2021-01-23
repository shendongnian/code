    <Grid>
		<DataGrid
            ItemsSource="{Binding items}" 
            AutoGenerateColumns="False"  
            IsManipulationEnabled="False">
			<DataGrid.Columns>
				<DataGridTextColumn 
                    Header="Name"
                    IsReadOnly="True" 
                    Binding="{Binding Name}" />
				<DataGridTextColumn
                    Header="Content"              
                    IsReadOnly="True"
                    Binding="{Binding DataDisplay}"/>
			</DataGrid.Columns>
		</DataGrid>
	</Grid>
