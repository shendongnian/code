        <DataGridTemplateColumn Width="auto" CellStyle="{StaticResource CenterCellStyle}" >
            <DataGridTemplateColumn.Header>
                <Label  Content="Header 1  " Foreground="White"  />
            </DataGridTemplateColumn.Header>
            <DataGridTemplateColumn.CellTemplate >
                <DataTemplate  >
                    <StackPanel Orientation="Horizontal" Margin="4,0,0,0">
                        <Image Margin="2">
                            <Image.Resources>
                                <Style TargetType="{x:Type Image}">
                                    <Style.Triggers>
                                        <DataTrigger Binding="{Binding ANSWER}" Value="Yes">
                                             <Setter Property="Visibility" Value="Visible" />
                                        </DataTrigger>
                                        <DataTrigger Binding="{Binding  ANSWER}" Value="No">
                                             <Setter Property="Visibility" Value="Collapsed" />
                                        </DataTrigger>
                                    </Style.Triggers>
                                </Style>
                            </Image.Resources>
                        </Image>
                                     
                    </StackPanel>
                </DataTemplate>
            </DataGridTemplateColumn.CellTemplate>
        </DataGridTemplateColumn>
 
