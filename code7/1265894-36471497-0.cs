    ResourceDictionary newRes = new ResourceDictionary();
    newRes.Source = new Uri("/PsyboInventory;component/TitleBarResource.xaml",UriKind.RelativeOrAbsolute);
    this.Resources.MergedDictionaries.Clear();
    this.Resources.MergedDictionaries.Add(newRes);
 
