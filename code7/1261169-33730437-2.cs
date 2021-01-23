        <ListView x:Name="listView1" Grid.Row="2" ItemsSource="{Binding VmUsers}">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <ContentPresenter Content="{Binding}">
                        <ContentPresenter.InputBindings>
                            <MouseBinding MouseAction="LeftDoubleClick" 
                                          Command="{Binding DataContext.MyCommand, ElementName=listView1}" 
                                          CommandParameter="{Binding ElementName=listView1,Path=SelectedItem}"/>
                        </ContentPresenter.InputBindings>
                    </ContentPresenter>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
