    <Page.Resources>
        <local:BooleanToVisibilityConverter x:Key="VisibilityConverter"/>
    </Page.Resources>
    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <ListView ItemsSource="{x:Bind Activities}">
            <ListView.ItemTemplate>
                <DataTemplate x:DataType="local:Activity">
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="3*"/>
                            <ColumnDefinition Width="1*"/>
                        </Grid.ColumnDefinitions>
                        <TextBlock x:Name="txt" Text="{x:Bind Name}" Grid.Column="0"/>
                        <Button x:Name="delItem" Click="delItem_Click" Grid.Column="1" Visibility="{x:Bind Visible, Mode=OneWay, Converter={StaticResource VisibilityConverter}}" Background="Transparent" Margin="100, 0, 0, 0">
                            <SymbolIcon Symbol="Delete"/>
                        </Button>
                    </Grid>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
    </Grid>
