        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height="auto" />
                <RowDefinition />
            </Grid.RowDefinitions>
            <StackPanel Grid.Column="1">
                <TextBlock Text="Length" HorizontalAlignment="Center"/>
                <TextBox />
                <StackPanel.Style>
                    <Style TargetType="StackPanel">
                        <Style.Triggers>
                            <DataTrigger Binding="{Binding RelativeSource={RelativeSource FindAncestor,AncestorType=s:DesignerItem}}" 
                                         Value="{x:Null}">
                                <Setter Property="Visibility" Value="Collapsed"/>
                            </DataTrigger>
                        </Style.Triggers>
                    </Style>
                </StackPanel.Style>
            </StackPanel>
            <Path Style="{StaticResource Decision}" 
                Grid.Row="1" Grid.Column="1"
                ToolTip="Decision">
                <s:DesignerItem.MoveThumbTemplate>
                    <ControlTemplate>
                        <Path Style="{StaticResource Decision_DragThumb}" />
                    </ControlTemplate>
                </s:DesignerItem.MoveThumbTemplate>
            </Path>
        </Grid>
