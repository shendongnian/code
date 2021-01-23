    <DataGrid Name="TestGrid1" AutoGenerateColumns="False">
        <DataGrid.Columns>
            <DataGridTemplateColumn Header="Name">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding Name}">
                            <TextBlock.ToolTip>
                                <ToolTip />
                            </TextBlock.ToolTip>
                        </TextBlock>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
            <DataGridTemplateColumn Header="Code">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding Code}">
                            <TextBlock.ToolTip>
                                <ToolTip />
                            </TextBlock.ToolTip>
                        </TextBlock>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
            <DataGridTemplateColumn Header="Description">
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding Description}">
                            <TextBlock.ToolTip>
                                <ToolTip />
                            </TextBlock.ToolTip>
                        </TextBlock>
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
        </DataGrid.Columns>
        <DataGrid.Resources>
            <Style TargetType="ToolTip">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="ToolTip">
                            <Border CornerRadius="15,15,15,15" 
                                    BorderThickness="3,3,3,3" 
                                    Background="#AA000000"  
                                    BorderBrush="#99FFFFFF"
                                    RenderTransformOrigin="0.5,0.5">
                                <Grid>
                                    <Grid.RowDefinitions>
                                        <RowDefinition Height="2*"/>
                                        <RowDefinition/>
                                        <RowDefinition/>
                                    </Grid.RowDefinitions>
                                    <TextBlock Grid.Row="0" Text="{Binding Name}"/>
                                    <TextBlock Grid.Row="1" Text="{Binding Code}"/>
                                    <TextBlock Grid.Row="2" Text="{Binding Description}"/>
                                </Grid>
                            </Border>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </DataGrid.Resources>
    </DataGrid>
