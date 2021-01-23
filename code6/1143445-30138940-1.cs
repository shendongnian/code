    <Window x:Class=...
            ...>
        <Window.Resources>
            <ResourceDictionary>
                <ResourceDictionary.MergedDictionaries>
                    <ResourceDictionary Source="Resources/Dictionary1.xaml"/>
                    <ResourceDictionary>
                        <!-- Window specific resources -->
                    </ResourceDictionary>
                </ResourceDictionary.MergedDictionaries>
            </ResourceDictionary>
        </Window.Resources>
        <!-- Content -->
    </Window>
