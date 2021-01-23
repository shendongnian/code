    <Grid x:Name="LayoutRoot" Background="transparent">
        <Grid.Resources>
            <Style TargetType="ListViewItem">
                <Setter Value="0.5" Property="Opacity"/>
            </Style>
        </Grid.Resources>
        <Pivot x:Name="MainPivot" Binding = {...}>
            ...
            <Pivot.ItemTemplate>
                <DataTemplate>
                    <ListView Binding = {...}>
                        ...
                    </ListView>
                </DataTemplate>
            </Pivot.ItemTemplate>
        </Pivot>
    </Grid>
