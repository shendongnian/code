     <TabControl Name="MyTabControl">
            <TabItem Header="Tab1">
                <TabItem.HeaderTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Horizontal">
                            <Image Source="/Images/a.png" />
                            <TextBlock Text="{Binding}"/>
                        </StackPanel>
                    </DataTemplate>
                </TabItem.HeaderTemplate>
            </TabItem>
            <TabItem Header="Tab2">
                <TabItem.HeaderTemplate>
                    <DataTemplate>
                        <StackPanel Orientation="Horizontal">
                            <Image Source="/Images/b.png" />
                            <TextBlock Text="{Binding}"/>
                        </StackPanel>
                    </DataTemplate>                   
                </TabItem.HeaderTemplate>
            </TabItem>
        </TabControl>
        <Label Content="{Binding ElementName=MyTabControl, Path=SelectedItem.Header}"/>
