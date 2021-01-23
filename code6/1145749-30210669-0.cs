    <Grid>
            <Grid.Resources>
                <ContextMenu x:Key="MenuOne">
                    <MenuItem Header="First Menu"/>
                    <MenuItem Header="First Menu"/>
                    <MenuItem Header="First Menu"/>
                </ContextMenu>
                <ContextMenu x:Key="MenuTwo">
                    <MenuItem Header="Second Menu"/>
                    <MenuItem Header="Second Menu"/>
                    <MenuItem Header="Second Menu"/>
                </ContextMenu>
            </Grid.Resources>
            <TreeView Name="SymbolsTreeView">
                <TreeView.Resources>
                    <Style TargetType="{x:Type TreeViewItem}">
                        <Setter Property="ContextMenu" Value="{StaticResource MenuOne}"/>
                        <Style.Triggers>
                            <DataTrigger Binding="{Binding Tag,RelativeSource={RelativeSource Self}}" Value="2">
                                <Setter Property="ContextMenu" Value="{StaticResource MenuTwo}"/>
                            </DataTrigger>
                        </Style.Triggers>
                    </Style>
                </TreeView.Resources>
                <TreeViewItem Header="Symbols1" IsExpanded="True" Tag="1" >
                    <TreeViewItem Header="Symbols2" IsExpanded="True" Tag="2" />
                </TreeViewItem>
                <TreeViewItem Header="Symbols1" IsExpanded="True" Tag="1" >
                    <TreeViewItem Header="Symbols2" IsExpanded="True" Tag="2" />
                </TreeViewItem>
            </TreeView>
        </Grid>
