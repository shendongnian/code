                 <DataTemplate>
                        <Grid>
                            <Grid.RowDefinitions>
                                <RowDefinition />
                                <RowDefinition />
                            </Grid.RowDefinitions>
                            <Grid Margin="4">
                                <Grid.ColumnDefinitions>
                                    <ColumnDefinition Width="Auto"></ColumnDefinition>
                                    <ColumnDefinition Width="*" />
                                    <ColumnDefinition Width="2*" />
                                </Grid.ColumnDefinitions>
                                <CheckBox>
                                    <CheckBox.Style>
                                        <Style TargetType="CheckBox">
                                            <Style.Triggers>
                                                <DataTrigger Binding="{Binding Type}" Value="BOOL">
                                                    <Setter Property="Visibility" Value="Collapsed"></Setter>
                                                </DataTrigger>
                                            </Style.Triggers>
                                        </Style>
                                    </CheckBox.Style>
                                </CheckBox>
                                <TextBlock Grid.Column="2"  Text="{Binding AttributeName}" />
                                <TextBox Text="{Binding AttributeValue}" Grid.Column="2" />
                            </Grid>
                            <Separator Style="{StaticResource {x:Static ToolBar.SeparatorStyleKey}}" Grid.Row="1"/>
                        </Grid>
                    </DataTemplate>
