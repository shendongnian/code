    <Grid>
	    <Grid.ColumnDefinitions>
	        <ColumnDefinition Width="7*"/>
            <ColumnDefinition Width="{Binding Width}"/>
        </Grid.ColumnDefinitions>
		
        <ContentPresenter Content="{Binding ViewManager.EditorControlView}" Grid.Column="0"/>
        <ContentPresenter Content="{Binding ViewManager.ExtendedControlView}" Grid.Column="1"/>
    </Grid>
