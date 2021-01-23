    <ControlTemplate TargetType="controls:ModernTab">
                        <Grid>
                            <!-- link list -->
                            <ListBox x:Name="LinkList" ItemsSource="{TemplateBinding Links}" HorizontalAlignment="Left" VerticalAlignment="Top" Margin="{DynamicResource HeaderMargin}"
                                     ScrollViewer.HorizontalScrollBarVisibility="Hidden"
                                     ScrollViewer.VerticalScrollBarVisibility="Hidden"
                                     ScrollViewer.CanContentScroll="False"
                                     ScrollViewer.PanningMode="Both">
                                <ListBox.ItemContainerStyle>
                                    <Style TargetType="ListBoxItem">
                                        <Setter Property="FocusVisualStyle" Value="{x:Null}" />
                                        <Setter Property="FontFamily" Value="Segoe UI" />
                                        <Setter Property="Foreground" Value="{DynamicResource MenuText}" />
                                        <Setter Property="FontSize" Value="15"/>
                                        <Setter Property="FontWeight" Value="Bold" />
                                        <Setter Property="TextOptions.TextFormattingMode" Value="Ideal" />
                                        <Setter Property="Foreground" Value="{DynamicResource MenuText}" />
                                        <Setter Property="Margin" Value="12,0,0,0" />
                                        <Setter Property="Template">
                                            <Setter.Value>
                                                <ControlTemplate TargetType="{x:Type ListBoxItem}">
                                                    <ContentPresenter x:Name="Presenter"
                                                                      HorizontalAlignment="{TemplateBinding HorizontalContentAlignment}"
                                                                      VerticalAlignment="{TemplateBinding VerticalContentAlignment}"
                                                                      SnapsToDevicePixels="{TemplateBinding SnapsToDevicePixels}"/>
                                                    <ControlTemplate.Triggers>
                                                        <Trigger Property="IsMouseOver" Value="true">
                                                            <Setter Property="Foreground" Value="{DynamicResource MenuTextHover}"/>
                                                        </Trigger>
                                                        <Trigger Property="IsSelected" Value="true">
                                                            <Setter Property="Foreground" Value="{DynamicResource MenuTextSelected}"/>
                                                        </Trigger>
                                                    </ControlTemplate.Triggers>
                                                </ControlTemplate>
                                            </Setter.Value>
                                        </Setter>
                                    </Style>
                                </ListBox.ItemContainerStyle>
    
                                <ListBox.ItemsPanel>
                                    <ItemsPanelTemplate>
                                        <StackPanel Orientation="Horizontal" />
                                    </ItemsPanelTemplate>
                                </ListBox.ItemsPanel>
    
                                <ListBox.ItemTemplate>
                                    <DataTemplate>
                                        <TextBlock Text="{Binding DisplayName, Converter={StaticResource ToUpperConverter}}" />
                                    </DataTemplate>
                                </ListBox.ItemTemplate>
                            </ListBox>
    
                            <!-- content -->
                            <controls:ModernFrame Source="{Binding SelectedSource, RelativeSource={RelativeSource TemplatedParent}, Mode=TwoWay}" ContentLoader="{TemplateBinding ContentLoader}" />
                        </Grid>
                    </ControlTemplate>
