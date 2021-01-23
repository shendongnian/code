    <Window.Resources>
        <local:HeightMultiConverter x:Key="heightMutliConverter"/>
        <sys:Int32 x:Key="param">10</sys:Int32>
    </Window.Resources>
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition >
                <RowDefinition.Height>
                    <MultiBinding Converter="{StaticResource heightMutliConverter}">
                        <Binding Path="EditEnabled"/>
                        <Binding Source="{StaticResource param}"/>
                    </MultiBinding>
                </RowDefinition.Height>
            </RowDefinition>
        </Grid.RowDefinitions>
    </Grid>
