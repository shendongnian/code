    public partial class App : Application
        {
            public ResourceDictionary ThemeDictionary
            {
                // You could probably get it via its name with some query logic as well.
                get { return Resources.MergedDictionaries[0]; }
            }
        
            public void ChangeTheme(Uri uri)
            {
                ThemeDictionary.MergedDictionaries.Clear();
                ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
            } 
           
        }   
        <Application.Resources>
            <ResourceDictionary>
                <ResourceDictionary.MergedDictionaries>
                    <ResourceDictionary x:Name="ThemeDictionary">
                        <ResourceDictionary.MergedDictionaries>
                            <ResourceDictionary Source="/Themes/ShinyRed.xaml"/>
                        </ResourceDictionary.MergedDictionaries>
                    </ResourceDictionary>
        </ResourceDictionary.MergedDictionaries>
