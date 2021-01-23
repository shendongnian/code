    <ItemsControl ItemsSource="{Binding MyViewModelCollection}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <WrapPanel Orientation="Horizontal"/>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.Resources>
            <DataTemplate DataType="{x:Type myNameSpace:myViewModel1}">
                 <myNameSpace:myControl2/>
            </DataTemplate>
            <DataTemplate DataType="{x:Type myNameSpace:myViewModel2}">
                 <myNameSpace:myControl2/>
            </DataTemplate>
        </ItemsControl.Resources>
    </ItemsControl>
