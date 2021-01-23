    <Page.Resources>
        <CollectionViewSource x:Name="DataCollection" IsSourceGrouped="true" />
    </Page.Resources>
    <Grid>
        <GridView SelectionMode="None"   ItemsSource="{Binding Source={StaticResource DataCollection}}" >
            <GridView.ItemContainerStyle>
                <Style TargetType="GridViewItem">
                    <Setter Property="HorizontalContentAlignment" Value="Stretch"></Setter>
                    <Setter Property="VerticalContentAlignment" Value="Stretch"></Setter>
                </Style>
            </GridView.ItemContainerStyle>
            <GridView.ItemsPanel>
                <ItemsPanelTemplate>
                    <StackPanel Orientation="Vertical"/>
                </ItemsPanelTemplate>
            </GridView.ItemsPanel>
            <GridView.ItemTemplate>
                <DataTemplate>
                    <Grid Background="{Binding GroupeBrush}">
                        <TextBlock Text="{Binding Prop2}" />
                    </Grid>                    
                </DataTemplate>
            </GridView.ItemTemplate>
        </GridView>
    </Grid>
