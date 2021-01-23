        public ViewModelBase ContainerContent
                {
                    get
                    {
                        return _containerContent;
                    }
                    set
                    {
                        if (_containerContent != null)
                            _containerContent.Cleanup();
        
                        _containerContent = value;
                        RaisePropertyChanged("ContainerContent");
                    }
                }
        
                public void QuitCurrentContainerViewModel<T>() where T : class
                {
                    ContainerContent = null;
                    Task.Factory.StartNew(() =>
                    {
                        if (SimpleIoc.Default.ContainsCreated<T>())
                        {
                            SimpleIoc.Default.Unregister<T>();
                            GC.Collect();
                        }
    //TODO: Do navigation or change of content    
                    });
                }
