    <UserControl>
    
        <UserControl.DataContext>
            <YourViewModel/>
        </UserControl.DataContext>	
    	
    	<UserControl.Resources>        
    		<CollectionViewSource Source="{Binding Path=ElementsInViewModel}" x:Key="Cvs">
            </CollectionViewSource>
        
            <HierarchicalDataTemplate DataType="{x:Type DomainModel:YourDomainType}"
                                      ItemsSource="{Binding Path=ChildElements}">
                <TextBlock Text="{Binding Path=Name}"/>            
            </HierarchicalDataTemplate>        
        
            <Style TargetType="{x:Type TreeViewItem}">
                <Setter Property="IsExpanded" Value="{Binding IsExpanded, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}">
                </Setter>
                <Setter Property="IsSelected" Value="{Binding IsSelected, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}">
                </Setter>            
            </Style>
            
        </UserControl.Resources>
        
        
        <DockPanel>
            <TreeView ItemsSource="{Binding Source={StaticResource Cvs}}"/>
    	</DockPanel>
    	
    </UserControl>
    public class YourViewModel
    {
    
        public ObservableCollection<YourDomainType> ElementsInViewModel 
        {
            get
            {
                return _elementsInViewModel;
            }
            set
            {
                if (_elementsInViewModel != value)
                {
                    _elementsInViewModel = value;
                    RaisePropertyChanged("ElementsInViewModel");
                }
            }
        }
        ObservableCollection<YourDomainType> _elementsInViewModel;
    
    
        public YourViewModel()
        {
    
        }
    }
    public class YourDomainType
    {
        public ObservableCollection<YourDomainType> ChildElements
        {
            get
            {
                return _childElements;
            }
            set
            {
                if (_childElements != value)
                {
                    _childElements = value;
                    RaisePropertyChanged("ChildElements");
                }
            }
        }
        ObservableCollection<YourDomainType> _childElements;
        public bool IsExpanded
        {
            get
            {
                return _isExpanded;
            }
            set
            {
                if (_isExpanded != value)
                {
                    _isExpanded = value;
                    RaisePropertyChanged("IsExpanded");
                }
            }
        }
        bool _isExpanded;
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    RaisePropertyChanged("IsSelected");
                }
            }
        }
        bool _isSelected;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }
        string _name;
    }
