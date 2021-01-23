    <UserControl.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <ResourceDictionary Source="pack://application:,,,/Styles;component/Resources.xaml" />
            </ResourceDictionary.MergedDictionaries>
            <vm:DeviceSelectorViewModel x:Key="myViewModel" x:Name="myVM" />
        </ResourceDictionary>
    </UserControl.Resources>
    
    <UserControl.DataContext>
        <StaticResourceExtension ResourceKey="myViewModel"/>
    </UserControl.DataContext>
