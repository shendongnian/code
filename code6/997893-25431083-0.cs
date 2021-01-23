    <TreeView.ItemContainerStyle>
        <Style BasedOn="{StaticResource {x:Type TreeViewItem}}" TargetType="{x:Type TreeViewItem}">
            <Setter Property="BorderBrush" Value="Transparent" />
            <Setter Property="BorderThickness" Value="0" />
            <Setter Property="cs:TreeViewItemBehavior.IsBroughtIntoViewWhenSelected" Value="True" />
            <Setter Property="IsExpanded" Value="{Binding IsExpanded, Mode=TwoWay}" />
            <Setter Property="IsSelected" Value="{Binding IsSelected, Mode=TwoWay}" />
            <Style.Triggers>
                <Trigger Property="IsSelected" Value="True">
                    <Setter Property="BorderBrush" Value="{DynamicResource TVIBorderSelected}" />
                    <Setter Property="BorderThickness" Value="1" />
                </Trigger>
            </Style.Triggers>
        </Style>
    </TreeView.ItemContainerStyle>
    <TreeView.Resources>
        <HierarchicalDataTemplate DataType="{x:Type vm:FileSystemNode}"
                                  ItemsSource="{Binding Children}">
               <Border Name="SpacerBorder"
                       BorderThickness="2">
                   <!-- Add this -->
                   <Border.Style>
                      <Style TargetType="Border">
                         <Style.Triggers>
                            <DataTrigger Binding="{Binding RelativeSource={RelativeSource AncestorType=TreeViewItem}, Path=IsSelected}" Value="True">
                               <Setter Property="BorderBrush" Value="White"/>                               
                            </DataTrigger>
                         </Style.Triggers>
                      </Style>
                   </Border.Style>
                   <StackPanel Orientation="Horizontal">
                       <Image Name="PART_Image"
                              Height="15"
                              Source="{Binding Path=Icon}"
                              Width="15" />
                       <TextBlock Margin="5,0"
                                  Name="PART_Content"
                                  Text="{Binding Path=Name}" />
                   </StackPanel>
               </Border>
           </HierarchicalDataTemplate>
    </TreeView.Resources>
