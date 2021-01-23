    <DataGrid.RowStyle>
        <Style TargetType="DataGridRow">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type DataGridRow}">
                        <Grid>
                            <!-- 
                            Stole content presentation from here: 
                            http://stackoverflow.com/a/14266323/424129
                            -->
                            <SelectiveScrollingGrid>
                                <SelectiveScrollingGrid.ColumnDefinitions>
                                    <ColumnDefinition Width="Auto" />
                                    <ColumnDefinition Width="*" />
                                </SelectiveScrollingGrid.ColumnDefinitions>
                                <SelectiveScrollingGrid.RowDefinitions>
                                    <RowDefinition Height="*" />
                                    <RowDefinition Height="Auto" />
                                </SelectiveScrollingGrid.RowDefinitions>
                                <DataGridCellsPresenter 
                                    Grid.Column="1"
                                    ItemsPanel="{TemplateBinding ItemsPanel}"
                                    SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}" 
                                    />
                                <DataGridDetailsPresenter 
                                    Grid.Column="1"
                                    Grid.Row="1"
                                    SelectiveScrollingGrid.SelectiveScrollingOrientation="{Binding AreRowDetailsFrozen, ConverterParameter={x:Static SelectiveScrollingOrientation.Vertical}, Converter={x:Static DataGrid.RowDetailsScrollingConverter}, RelativeSource={RelativeSource AncestorType={x:Type DataGrid}}}"
                                    Visibility="{TemplateBinding DetailsVisibility}" 
                                    />
                                <DataGridRowHeader 
                                    Grid.RowSpan="2"
                                    SelectiveScrollingGrid.SelectiveScrollingOrientation="Vertical"
                                    Visibility="{Binding HeadersVisibility, ConverterParameter={x:Static DataGridHeadersVisibility.Row}, Converter={x:Static DataGrid.HeadersVisibilityConverter}, RelativeSource={RelativeSource AncestorType={x:Type DataGrid}}}" 
                                    />
                            </SelectiveScrollingGrid>
                            <Popup
                                x:Name="RowPopup"
                                IsOpen="{Binding IsSelected, RelativeSource={RelativeSource TemplatedParent}}"
                                >
                                <Border 
                                    MinWidth="200" 
                                    MinHeight="166" 
                                    Background="WhiteSmoke"
                                    BorderBrush="Black"
                                    BorderThickness="1"
                                    Padding="12"
                                    >
                                    <TextBlock>
                                        <TextBlock Text="Blah blah popup. " />
                                        <TextBlock Text="{Binding IsOdd, StringFormat=IsOdd: {0} }" />
                                    </TextBlock>
                                </Border>
                            </Popup>
                        </Grid>
                        <ControlTemplate.Triggers>
                            <!-- 
                            The RelativeSource=TemplatedParent binding doesn't seem to be working here. 
                            I don't understand why not. Probably something stupid and obvious. 
                            -->
                            <!-- 
                            <MultiDataTrigger>
                                <MultiDataTrigger.Conditions>
                                    <Condition 
                                        Binding="{Binding Path=IsSelected, RelativeSource={RelativeSource TemplatedParent}}" 
                                        Value="True" />
                                    <Condition Binding="{Binding IsOdd}" Value="False" />
                                </MultiDataTrigger.Conditions>
                                <Setter TargetName="RowPopup" Property="IsOpen" Value="True" />
                            </MultiDataTrigger>
                            -->
                            <!-- 
                            So instead, we bind IsOpen on the popup to IsSelected, and then 
                            override that with False if the boolean property is true. Clumsy 
                            but it works. 
                            -->
                            <DataTrigger Binding="{Binding IsOdd}" Value="True">
                                <Setter TargetName="RowPopup" Property="IsOpen" Value="False" />
                            </DataTrigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </DataGrid.RowStyle>
