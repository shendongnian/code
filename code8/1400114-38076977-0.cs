    <Style x:Key="GroupContainerStyle" TargetType="{x:Type GroupItem}">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type GroupItem}">                            
                    <Expander IsExpanded="True" Background="#414040" Tag="{Binding ElementName=root, Path=DataContext}">
                        <Expander.ContextMenu>
                            <ContextMenu Tag="{Binding Path=PlacementTarget.Tag, RelativeSource={RelativeSource Self}}">
                                <MenuItem Header="Delete group"
                                            Command="{Binding Tag.DeleteGroupCommand, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=ContextMenu}}"
                                            CommandParameter="{Binding Items[0].Key}" />
                            </ContextMenu>
                        </Expander.ContextMenu>                            
                        <Expander.Header>
                            <Grid>
                                <TextBlock Text="{Binding Path=Items[0].Key.Name}"/>
                            </Grid>
                        </Expander.Header>
                        <ItemsPresenter />
                    </Expander>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
