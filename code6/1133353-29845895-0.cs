        public class NewTaskViewModel : INotifyPropertyChanged
    	{
    		public event PropertyChangedEventHandler PropertyChanged;
    		protected void OnPropertyChanged(string name)
    		{
    			if (PropertyChanged != null)
    				PropertyChanged(this, new PropertyChangedEventArgs(name));
    		}
    	    public ICollectionView Projects { get; set; }
            private ICollectionView _Tasks;
            public ICollectionView Tasks
            {
              get {return _Tasks;}
              set
              {
                  if(_Tasks != value)
                  {
                     _Tasks = value;
                     OnPropertyChanged("Tasks");
                  }
              }
            }
    
            public ICollectionView Users { get; set; }
            public NewTaskViewModel()
            {
            Projects = new CollectionView(this.GetProjects());
            Projects.CurrentChanged += new EventHandler(projects_CurrentChanged);
                 Users = new CollectionView(this.GetProjectAssignedUsers());
            }
    
            void projects_CurrentChanged(object sender, EventArgs e)
            {
                 Api.Project project = Projects.CurrentItem as Api.Project;
                 this.SelectedProjectId = project.Id;
                 this.Tasks = new CollectionView(this.GetTaskLists());
            }
    }
