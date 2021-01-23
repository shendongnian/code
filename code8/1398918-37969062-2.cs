    public class ViewModelLocator
        {
            static ViewModelLocator()
            {
                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
                SimpleIoc.Default.Register<MainViewModel>();
            }
    
            /// <summary>
            /// Gets the Main property.
            /// </summary>
            public MainViewModel Main
            {
                get
                {
                    return ServiceLocator.Current.GetInstance<MainViewModel>();
                }
            }
        }
