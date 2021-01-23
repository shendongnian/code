        <TabControl SelectionChanged="Selector_OnSelectionChanged" Grid.Row="0" >
            <TabItem Header="DoSmth">
            </TabItem>
            <TabItem Header="Misc" >
                <Grid>
                    <Grid.RowDefinitions>
                        <RowDefinition Name="GridRow1">
                            <RowDefinition.Style>
                                <Style TargetType="{x:Type RowDefinition}">
                                    <Setter Property="Height"  Value="Auto" />
                                    <Style.Triggers>
                                        <DataTrigger Binding="{Binding ElementName=Misc1Expander,
                                            Path=IsExpanded}" Value="True">
                                            <Setter Property="Height" Value="*" />
                                        </DataTrigger>
                                    </Style.Triggers>
                                </Style>
                            </RowDefinition.Style>
                        </RowDefinition>
                        <RowDefinition Name="GridRow2">
                            <RowDefinition.Style>
                                <Style TargetType="{x:Type RowDefinition}">
                                    <Setter Property="Height"  Value="Auto" />
                                    <Style.Triggers>
                                        <DataTrigger Binding="{Binding ElementName=Misc2Expander,
                                            Path=IsExpanded}" Value="True">
                                            <Setter Property="Height" Value="*" />
                                        </DataTrigger>
                                    </Style.Triggers>
                                </Style>
                            </RowDefinition.Style>
                        </RowDefinition>
                        <RowDefinition Name="GridRow3">
                            <RowDefinition.Style>
                                <Style TargetType="{x:Type RowDefinition}">
                                    <Setter Property="Height"  Value="Auto" />
                                    <Style.Triggers>
                                        <DataTrigger Binding="{Binding ElementName=Misc3Expander,
                                            Path=IsExpanded}" Value="True">
                                            <Setter Property="Height" Value="*" />
                                        </DataTrigger>
                                    </Style.Triggers>
                                </Style>
                            </RowDefinition.Style>
                        </RowDefinition>
                    </Grid.RowDefinitions>
                    <Expander Grid.Row="0"
                        Header="Misc2" IsExpanded="False" x:Name="Misc1Expander" Margin="0,10,0,0">
                        <view:Misc2View Background="WhiteSmoke"/>
                    </Expander>
                    <Expander Grid.Row="1"
                        Header="Misc2" IsExpanded="False" x:Name="Misc2Expander" Margin="0,10,0,0">
                        <view:Misc2View Background="WhiteSmoke"/>
                    </Expander>
                    <Expander Grid.Row="2"
                        Header="Misc2" IsExpanded="False" x:Name="Misc3Expander" Margin="0,10,0,0">
                        <view:Misc2View Background="WhiteSmoke"/>
                    </Expander>
                </Grid>
            </TabItem>
        </TabControl>
