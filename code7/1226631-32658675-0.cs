    <Button x:Name="myButton" Style="{StaticResource AppBarButtonStyle}">
        <Button.Resources>
            <ResourceDictionary>
                <ResourceDictionary.MergedDictionaries>
                     <ResourceDictionary Source="pack://application:,,,/YourAssembly;component/Resources/ButtonStyles.xaml"/> <!--Basically your path to the ResourceDictionary-->
                </ResourceDictionary.MergedDictionaries>
            </ResourceDictionary>
         </Button.Resources>
    </Button>
