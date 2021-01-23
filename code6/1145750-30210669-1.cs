    <Grid>
        <Grid.Resources>
            <ContextMenu x:Key="MenuOne">
                <MenuItem Header="First Menu"/>
                <MenuItem Header="First Menu"/>
                <MenuItem Header="First Menu"/>
            </ContextMenu>
        </Grid.Resources>
        <TreeView Name="SymbolsTreeView">
            <TreeView.Resources>
                <Style TargetType="{x:Type TreeViewItem}">
                    <Setter Property="ContextMenu" Value="{StaticResource MenuOne}"/>
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding Header,RelativeSource={RelativeSource Self}}" Value="Symbols">
                            <Setter Property="ContextMenu" Value="{x:Null}"/>
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </TreeView.Resources>
            <TreeViewItem Header="Symbols" IsExpanded="True">
            <TreeViewItem Header="Symbols1" IsExpanded="True" Tag="1" >
                <TreeViewItem Header="Symbols2" IsExpanded="True" Tag="2" />
            </TreeViewItem>
            <TreeViewItem Header="Symbols1" IsExpanded="True" Tag="1" >
                <TreeViewItem Header="Symbols2" IsExpanded="True" Tag="2" />
            </TreeViewItem>
            </TreeViewItem>
        </TreeView>
    </Grid>
