    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.CommandWpf;
    
    namespace WpfContextMenuWithEnum
    {
    	public class MainWindowModel : ViewModelBase
    	{
    		private EnumChoice _selectedEnumChoice;
    
    		public EnumChoice SelectedEnumChoice
    		{
    			get { return _selectedEnumChoice; }
    			set { _selectedEnumChoice = value; RaisePropertyChanged(); }
    		}
    	}
    }
