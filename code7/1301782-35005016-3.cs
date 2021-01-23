	public interface INameable
	{
		string Name { get; set; }
	}
	public class Quest : ViewModelBase, INameable
	{
		private string _name;
		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				RaisePropertyChanged();
			}
		}
		private ObservableCollection<Dialogue> _Dialogues;
		public ObservableCollection<Dialogue> Dialogues
		{
			get { return this._Dialogues; }
			set { this._Dialogues = value; RaisePropertyChanged(); }
		}
		private ICollectionView _SortedDialogues;
		public ICollectionView SortedDialogues
		{
			get { return this._SortedDialogues; }
			set { this._SortedDialogues = value; RaisePropertyChanged(); }
		}
		public Func<object> GetSelected;
		public Action<object> SetSelected;
		
		public Quest()
		{
			Dialogues = new ObservableCollection<Dialogue>();
			this.SortedDialogues = CollectionViewSource.GetDefaultView(Dialogues);
			this.SortedDialogues.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
		}
		public void AddDialogue(Dialogue dlg)
		{
			this.Dialogues.Add(dlg);
			dlg.PropertyChanged += Dlg_PropertyChanged;
			SortDialogues();
		}
		private void Dlg_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			SortDialogues();
		}
		private void SortDialogues()
		{
			var selected = GetSelected(); // get currently selected item
			this.SortedDialogues.Refresh(); // bam! treeviewitmes get destroyed.
			SetSelected(selected); // so reselect it immediately
		}
	}
	public class Dialogue : ViewModelBase, INameable
	{
		private string _name;
		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				RaisePropertyChanged();
			}
		}
		
	}
	public partial class MainWindow : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		
		private object _selectedObject = new object();
		public object SelectedObject
		{
			get
			{
				return _selectedObject;
			}
			set
			{
				_selectedObject = value;
				OnPropertyChanged();
			}
		}
		public ObservableCollection<Quest> Quests
		{
			get { return _quests; }
			set
			{
				_quests = value;
				OnPropertyChanged();
			}
		}
		private ObservableCollection<Quest> _quests;		
		
		public MainWindow()
		{
			Quests = new ObservableCollection<Quest>();
			InitializeComponent();
		}
		private void AddQuest(object sender, RoutedEventArgs e)
		{
			Quests.Add(new Quest
			{
				Name = "Quest",
				GetSelected = () => this.SelectedObject,
				SetSelected = (selected) => {
					ItemContainerGenerator gen = _treeView.ItemContainerGenerator;
					TreeViewItem item = ContainerFromItem(gen, selected);
					if (item != null)
						item.IsSelected = true;
				}
				,
			});
		}
		private void AddDialogue(object sender, RoutedEventArgs e)
		{
			if (_treeView.SelectedItem is Quest)
			{
				var dlg = new Dialogue
				{
					Name = "Dialogue"
				};
				(_treeView.SelectedItem as Quest).AddDialogue(dlg);
			}
		}
		// courtesy http://stackoverflow.com/questions/24859511/get-treeviewitem-for-treeview-logical-element
		private static TreeViewItem ContainerFromItem(ItemContainerGenerator containerGenerator, object item)
		{
			TreeViewItem container = (TreeViewItem)containerGenerator.ContainerFromItem(item);
			if (container != null)
				return container;
			foreach (object childItem in containerGenerator.Items)
			{
				TreeViewItem parent = containerGenerator.ContainerFromItem(childItem) as TreeViewItem;
				if (parent == null)
					continue;
				container = parent.ItemContainerGenerator.ContainerFromItem(item) as TreeViewItem;
				if (container != null)
					return container;
				container = ContainerFromItem(parent.ItemContainerGenerator, item);
				if (container != null)
					return container;
			}
			return null;
		}
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
	}
