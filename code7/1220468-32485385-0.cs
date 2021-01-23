    public class City
    {
       public string Name {get;set;}
       public string SettingOne {get;set;}
       public string SettingTwo {get;set;}
    }
    <TabControl DataContext="{Binding Path=Cities}">
        <TabItem Header="Settings" x:Name="settingsTab">
            <TabItem.Content>
                <ListView ItemsSource="{Binding}">
                    <ListView.ItemTemplate>
                        <TextBox Text="{Binding Path=SettingOne}"></TextBox>
                         ...
                     </ListView.ItemTemplate>
                </StackPanel>
            </TabItem.Content>
        </TabItem>
    </TabControl>
