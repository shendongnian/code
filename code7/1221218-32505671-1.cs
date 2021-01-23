    <Application x:Class="WpfApplication13.App"
                     xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                     xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                     StartupUri="MainWindow.xaml">
            <Application.Resources>
                    <ResourceDictionary>
                        <ResourceDictionary.MergedDictionaries>
                            <ResourceDictionary Source="/MyDll;component/MyDllSubFolder/MyResourceDictionary.xaml" />
                        </ResourceDictionary.MergedDictionaries>
                        <Style TargetType="Control" x:Key="AStyleThatIsInTheAppAndNotTheDll">
                            <Setter Property="Template">
                                <Setter.Value>
                                    <ControlTemplate>
                                    </ControlTemplate>
                                </Setter.Value>
                            </Setter>
                        </Style>
                    </ResourceDictionary>
            </Application.Resources>
    </Application>
