    public void OnNavigatedTo(NavigationContext navigationContext)
            {
                var viewParentInstance = DockinWindowChildObjectDictionary.GetInstance("Belt Plan");
                viewParentInstance.IsSelected = true;
            }
