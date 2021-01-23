    <DataGrid AutoGenerateColumns="False" ItemsSource="{Binding People}">
    	<DataGrid.Columns>
    		<DataGridTextColumn Header="ID" Binding="{Binding ID}" />
    		<DataGridTextColumn Header="Name" Binding="{Binding Name}" />
    	</DataGrid.Columns>
    	<i:Interaction.Triggers>
    		<i:EventTrigger EventName="SelectionChanged">
    			<i:InvokeCommandAction Command="{Binding MyCommand}" />
    		</i:EventTrigger>
    	</i:Interaction.Triggers>
    </DataGrid>
