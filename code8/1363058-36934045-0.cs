    <Style x:Key="GroupHeaderSettingsStyle" TargetType="{x:Type GroupItem}">
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type GroupItem}">
                            <Expander x:Name="Exp" IsExpanded="{Binding RelativeSource={RelativeSource AncestorType={x:Type UserControl},Mode=FindAncestor},Path=DataContext.FilterExpander}">
                                <Expander.Header>
                                    <TextBlock Text="{Binding Name}" Foreground="White"/>
                                </Expander.Header>
                                <ItemsPresenter/>
                            </Expander>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
