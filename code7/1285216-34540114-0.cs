    public class MainViewModel : ViewModelBase
	{
		private YourInfoItem _selectedComboBoxItem;
		
		private ViewModel1 SkillsInfoVM = new ViewModel1();
		private ViewModel2 PersonalInfoVM = new ViewModel2();
		private ViewModel3 GeneralInfoVM = new ViewModel3();
		public YourInfoItem selectedComboBoxItem 
		{
			get {return _selectedComboBoxItem; }
			
			set 
			{
				_selectedComboBoxItem = value;
				PropertyChanged(nameof(selectedComboBoxItem));
			}
		}
		
		public MainViewModel()
		{            
			SelectedComboBoxItemChanged = new RelayCommand(SetSelectedComboBoxItem);
		}
		
		public ICommand SelectedComboBoxItemChanged { get; private set; }
		
		public void SetSelectedComboBoxItem()
		{
			SkillsInfoVM.selectedComboBoxItem = this.selectedComboBoxItem;
			PersonalInfoVM.selectedComboBoxItem = this.selectedComboBoxItem;
			GeneralInfoVM.selectedComboBoxItem = this.selectedComboBoxItem;
		}
	}
  
