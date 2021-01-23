    <TabControl>
            <TabControl.Resources>
                <Style TargetType="{x:Type TabPanel}">
                    <Setter Property="Background" Value="Yellow"/>
                </Style>
                <Style TargetType="{x:Type TabItem}">
                    <Setter Property="BorderThickness" Value="0"/>
                    <Setter Property="Padding" Value="0" />
                    <Setter Property="HeaderTemplate">
                        <Setter.Value>
                            <DataTemplate>
                                <Border x:Name="grid" Background="Red">
                                    <ContentPresenter>
                                        <ContentPresenter.Content>
                                            <Border BorderThickness="3" BorderBrush="Red" CornerRadius="5">
                                            <StackPanel>                                                
                                                <TextBlock Margin="4" FontSize="15" Text="{TemplateBinding Content}"/>
                                                <TextBlock>I am a header</TextBlock>
                                            </StackPanel>
                                            </Border>
                                        </ContentPresenter.Content>                                        
                                    </ContentPresenter>
                                </Border>
                                <DataTemplate.Triggers>
                                    <DataTrigger Binding="{Binding RelativeSource={RelativeSource Mode=FindAncestor,AncestorType={x:Type TabItem}},Path=IsSelected}" Value="True">
                                        <Setter TargetName="grid" Property="Background" Value="Green"/>
                                    </DataTrigger>
                                </DataTemplate.Triggers>
                            </DataTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </TabControl.Resources>
            <TabItem Header="{Binding PluginName}" Name="tabItem1">
            </TabItem>
        </TabControl>
