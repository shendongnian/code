                <TabControl Name="ViewModeListTabControl" Grid.Column="1"
                    ItemsSource="{Binding  UpdateSourceTrigger=PropertyChanged, NotifyOnSourceUpdated=True, Mode=OneWay}" 
                    SelectedItem="{Binding Path=SelectedViewModel,
            Mode=TwoWay, UpdateSourceTrigger=PropertyChanged, NotifyOnSourceUpdated=true}" ContentTemplate="{DynamicResource UCAnother}">
            <TabControl.Resources>
                    <DataTemplate x:Key="UCAnother"  DataType="{x:Type my:AnotherUserControl}" >
                        <my:AnotherUserControl DataContext="{Binding}"></my:AnotherUserControl>
                    </DataTemplate>
            </TabControl.Resources>
