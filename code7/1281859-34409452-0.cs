        <DataGrid.CellStyle>
        <Style TargetType="DataGridCell">
            <Setter Property="Background" Value="Tomato"/>
            <Setter Property="ToolTip">
                <Setter.Value>
                    <ToolTip>
                        <ToolTip.Style>
                            <Style TargetType="ToolTip">
                                <Setter Property="Template">
                                    <Setter.Value>
                                        <ControlTemplate TargetType="ToolTip">
                                            <Border CornerRadius="15,15,15,15" 
                                                        BorderThickness="3,3,3,3" 
                                                        Background="{Binding PlacementTarget.Background, RelativeSource={RelativeSource AncestorType=ToolTip, Mode=FindAncestor}}"  
                                                        BorderBrush="#99FFFFFF"
                                                        RenderTransformOrigin="0.5,0.5">
                                                <Grid>
                                                    <Grid.RowDefinitions>
                                                        <RowDefinition Height="2*"/>
                                                        <RowDefinition/>
                                                        <RowDefinition/>
                                                    </Grid.RowDefinitions>
                                                    <TextBlock Grid.Row="0" Text="{Binding PlacementTarget.DataContext.Name, RelativeSource={RelativeSource AncestorType=ToolTip, Mode=FindAncestor}}" 
                                                            />
                                                    <TextBlock Grid.Row="0" Text="{Binding PlacementTarget.DataContext.Code, RelativeSource={RelativeSource AncestorType=ToolTip, Mode=FindAncestor}}" 
                                                            />
                                                    <TextBlock Grid.Row="0" Text="{Binding PlacementTarget.DataContext.Description, RelativeSource={RelativeSource AncestorType=ToolTip, Mode=FindAncestor}}" 
                                                            />
                                                </Grid>
                                            </Border>
                                        </ControlTemplate>
                                    </Setter.Value>
                                </Setter>
                            </Style>
                        </ToolTip.Style>
                        
                    </ToolTip>
                </Setter.Value>
            </Setter>
        </Style>
        </DataGrid.CellStyle>
