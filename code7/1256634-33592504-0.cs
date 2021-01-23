    <Page
        ...
        x:Name="root">
        <Page.Resources>
            <Style TargetType="GridView" >
                <Setter Property="HeaderTemplate">
                    <Setter.Value>
                        <DataTemplate>
                            <Grid x:Name="GridHeader" Height="200">
                                <Grid.ColumnDefinitions>
                                    <ColumnDefinition Width="5*"/>
                                    <ColumnDefinition Width="{Binding ElementName=root, Path=TestGridLength}"/>
                                </Grid.ColumnDefinitions>
                                <Grid Background="Red" Grid.Column="0"></Grid>
                                <Grid Background="Green" Grid.Column="1"></Grid>
                            </Grid>
                        </DataTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </Page.Resources>
    
        <GridView Background="Purple">
        </GridView>
    </Page>
