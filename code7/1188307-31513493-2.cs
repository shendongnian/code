    <ItemsControl ItemsSource="{Binding Days}">         
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <UniformGrid Rows="6" Columns="7">                     
                </UniformGrid>                  
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <StackPanel>
                    <TextBlock Text="{Binding Date , Converter={StaticResource DateConverter}, ConverterParameter=DAY}"/>               
                    <!-- The ListBox's ItemsSource is bound to the ICollectionView of your Day class -->        
                    <ListBox  ItemsSource="{Binding Scenes}" dd:DragDrop.IsDragSource="True"
     dd:DragDrop.IsDropTarget="True" Height="100">
                    <ListBox.ItemTemplate>
                        <DataTemplate>
                            <StackPanel>
                                <TextBlock>
                                     <Run Text="{Binding Path=SceneNumber}"/>
                                     <Run Text="{Binding Path=SlugLine}"/>
                                </TextBlock>
                            </StackPanel>
                        </DataTemplate>
                    </ListBox.ItemTemplate>
                   </ListBox>
                </StackPanel>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
