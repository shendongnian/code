    <Grid>
        <Menu>
            <MenuItem Header="Properties" IsChecked="{Binding FileStats.IsVisible, Mode=TwoWay}" IsCheckable="True"/>
            <MenuItem Header="New" Command="{Binding NewCommand}"/>
        </Menu>
    </Grid>
