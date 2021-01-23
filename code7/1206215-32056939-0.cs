    <RadioButton x:Name="TimeRadioButton" Content="Time" />
    
    <GridViewColumn Header="Gap">
    	<GridViewColumn.CellTemplate>
    		<DataTemplate>
    			<Grid>
    				<TextBlock IsEnabled="{Binding IsChecked, ElementName=GapRadioButton}"/>
    			</Grid>
    		</DataTemplate>
    	</GridViewColumn.CellTemplate>
    </GridViewColumn>
