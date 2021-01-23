        <Grid>
        <Grid.DataContext>
            <soHelpProject:MainViewModel/>
        </Grid.DataContext>
        <ToggleButton IsChecked="{Binding IsToggled, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}">
            <TextBlock >UWP Toggle Button</TextBlock>
        </ToggleButton>
    </Grid>
