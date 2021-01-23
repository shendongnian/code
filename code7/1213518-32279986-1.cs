        <Grid>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="*"/>
                <ColumnDefinition Width="{Binding HasValue, Converter={StaticResource BoolToGridLengthConverter}, ConverterParameter='*'}"/>
            </Grid.ColumnDefinitions>
    
            <Grid Grid.Column="0">
                <!--  Some content here  -->
            </Grid>
    
            <Grid Grid.Column="1" Visibility="{Binding HasValue, Converter={StaticResource BooleanToVisibilityConverter}}">
                <!--  Some content here  -->
            </Grid>
        </Grid>
