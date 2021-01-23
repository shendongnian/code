    <Button Background="Red" Foreground="Black"> <!-- These are only applied when your button is not being hovered-->
        <Button.Resources>
            <ResourceDictionary>
                <ResourceDictionary.ThemeDictionaries>
                    <ResourceDictionary x:Key="Dark">
                        <SolidColorBrush x:Key="ButtonForegroundPointerOver" Color="Red"/>
                        <SolidColorBrush x:Key="ButtonBackgroundPointerOver" Color="Black"/>
                    </ResourceDictionary>
                    <ResourceDictionary x:Key="Light">
                        <SolidColorBrush x:Key="ButtonForegroundPointerOver" Color="Red"/>
                        <SolidColorBrush x:Key="ButtonBackgroundPointerOver" Color="Black"/>
                    </ResourceDictionary>
                </ResourceDictionary.ThemeDictionaries>
            </ResourceDictionary>
        </Button.Resources>
    </Button>
