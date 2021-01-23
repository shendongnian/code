    <ItemsControl ItemsSource="{Binding Controls}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <Grid Name="MainGrid">
                    <Grid.RowDefinitions>
                        <RowDefinition/>
                        <RowDefinition/>
                        <RowDefinition/>
                        <RowDefinition/>
                    </Grid.RowDefinitions>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition/>
                        <ColumnDefinition/>
                        <ColumnDefinition/>
                        <ColumnDefinition/>
                    </Grid.ColumnDefinitions>
                </Grid>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemContainerStyle>
            <Style TargetType="AppControls:TagInfo">
                <Setter Property="Grid.Row" Value="{Binding RowIndex}"/>
                <Setter Property="Grid.Column" Value="{Binding ColumnIndex}"/>
            </Style>
        </ItemsControl.ItemContainerStyle>
    </ItemsControl>
