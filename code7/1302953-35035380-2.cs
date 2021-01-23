    <Grid.Resources>
        <ResourceDictionary>
            <ControlTemplate TargetType="cars:Car2016Model" x:Key="Template">
                <Grid Background="Cyan">
                    <TextBox Text="{Binding Engine.Power, Mode=OneTime}" />
                </Grid>
            </ControlTemplate>
        </ResourceDictionary>
    </Grid.Resources>
