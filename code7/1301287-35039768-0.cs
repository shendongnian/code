    <ListView ItemsSource="{Binding Path=ItemsView}">
            <ListView.GroupStyle>
                <GroupStyle>
                    <GroupStyle.ContainerStyle>
                        <Style TargetType="{x:Type GroupItem}">
                            <Setter Property="Template">
                                <Setter.Value>
                                    <ControlTemplate TargetType="{x:Type GroupItem}">
                                        <ControlTemplate.Resources>
                                            <DataTemplate DataType="{x:Type local:ItemViewModel}">
                                                <TextBlock Text="{Binding Path=Section}" />
                                            </DataTemplate>
                                        </ControlTemplate.Resources>
                                        <Expander Background="{DynamicResource {x:Static SystemColors.ControlLightLightBrushKey}}">
                                            <Expander.Header>
                                                <StackPanel Margin="0,8,0,0"
                                                            HorizontalAlignment="Stretch"
                                                            Orientation="Horizontal">
                                                    <TextBlock x:Name="Title"
                                                               VerticalAlignment="Center"
                                                               FontWeight="Bold">
                                                        <Run Text="{Binding Path=Name, Mode=OneWay}" />
                                                        <Run Text=" " />
                                                        <Run Text="{Binding Path=Items.Count, Mode=OneWay}" />
                                                    </TextBlock>
                                                </StackPanel>
                                            </Expander.Header>
                                            <ItemsPresenter />
                                        </Expander>
                                    </ControlTemplate>
                                </Setter.Value>
                            </Setter>
                            <Style.Triggers>
                                <DataTrigger Binding="{Binding Path=Items.Count}" Value="1">
                                    <Setter Property="Template">
                                        <Setter.Value>
                                            <ControlTemplate TargetType="{x:Type GroupItem}">
                                                <ControlTemplate.Resources>
                                                    <DataTemplate DataType="{x:Type local:ItemViewModel}">
                                                        <TextBlock Text="{Binding Path=Document}" />
                                                    </DataTemplate>
                                                </ControlTemplate.Resources>
                                                <ItemsPresenter />
                                            </ControlTemplate>
                                        </Setter.Value>
                                    </Setter>
                                </DataTrigger>
                            </Style.Triggers>
                        </Style>
                    </GroupStyle.ContainerStyle>
                </GroupStyle>
            </ListView.GroupStyle>
        </ListView>
