    <UserControl x:Name=this>
        <Grid>
            <Grid.RowDefinitions>
                <RowDefiniton>
                <RowDefiniton>
                <RowDefiniton>
            </Grid.RowDefinition>
            <ContentControl Grid.Row="0" Content="{Binding PluginA.View, ElementName=this}"/>
            <ContentControl Grid.Row="1" Content="{Binding PluginB.View, ElementName=this}"/>
            <ContentControl Grid.Row="2" Content="{Binding PluginC.View, ElementName=this}"/>
        </Grid>
    </UserControl>
