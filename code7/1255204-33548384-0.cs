    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <!-- Styles that define common aspects of the platform look and feel
                     Required by Visual Studio project and item templates -->
                <ResourceDictionary Source="Common/StandardStyles.xaml" />
                <!-- App specific styles -->
                <ResourceDictionary Source="Assets/SomeStyles.xaml" />
                <ResourceDictionary Source="Assets/SomeMoreStyles.xaml" />
            </ResourceDictionary.MergedDictionaries>
           
            <vm:ViewModelLocator x:Key="Locator" />
            <!-- Converters -->
            <converters:BoolToVisibilityConverter x:Key="BoolToVisibilityConverter" />
            <converters:NullToVisibilityConverter x:Key="NullToVisibilityConverter" />
        </ResourceDictionary>
    </Application.Resources>
