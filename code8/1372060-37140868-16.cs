    <Window
        ...
        xmlns:nqrgui="clr-namespace:NQR_GUI_WPF"
        ...
        >
    <!-- Or better yet, merge ImageButton.xaml in App.xaml so everybody can see it -->
        <Window.Resources>
            <ResourceDictionary>
                <ResourceDictionary.MergedDictionaries>
                    <ResourceDictionary Source="ImageButton.xaml" />
                </ResourceDictionary.MergedDictionaries>
            </ResourceDictionary>
        </Window.Resources>
    ...
        <!-- As noted, Content, HighlightedContent, and ClickedContent 
        can be images -- or also paths, text, ANYTHING XAML can render.
        -->
        <nqrgui:ImageButton 
            Content="Content"
            HighlightedContent="Highlighted"
            ClickedContent="Clicked"
            />
