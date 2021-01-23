    using MVVMEditComboBoxItemsSample.MockModel;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;
    namespace MVVMEditComboBoxItemsSample
    {
        class MainViewModel : ViewModelBase
        {
            private ObservableCollection<Thing> things;
            private Thing selectedThing;
        private ICommand addCommand;
        private ICommand cloneCommand;
        private ICommand deleteCommand;
        public MainViewModel()
        {
            Things = new ObservableCollection<Thing>(ThingDataManager.Instance.GetThings());
            SelectedThing = Things.FirstOrDefault();
        }
        public ObservableCollection<Thing> Things
        {
            get
            {
                return things;
            }
            set
            {
                things = value;
                OnPropertyChanged(nameof(Things));
            }
        }
        public Thing SelectedThing
        {
            get
            {
                return selectedThing;
            }
            set
            {
                selectedThing = value;
                OnPropertyChanged(nameof(SelectedThing));
            }
        }
        public ICommand AddCommand
        {
            get
            {
                if(addCommand==null)
                {
                    addCommand = new CommandBase(i => AddItem(), null);
                }
                return addCommand;
            }
        }
        public ICommand CloneCommand
        {
            get
            {
                if(cloneCommand==null)
                {
                    cloneCommand = new CommandBase(i => CloneItem(), i => SelectedThing!=null);
                }
                return cloneCommand;
            }
        }
        public ICommand DeleteCommand
        {
            get
            {
                if(deleteCommand==null)
                {
                    deleteCommand = new CommandBase(i => DeleteItem(), i => SelectedThing!=null);
                }
                return deleteCommand;
            }
        }
        public void AddItem()
        {
            Thing newThing = new Thing();
            Things.Add(newThing);
            SelectedThing = newThing;
        }
        public void CloneItem()
        {
            Thing clonedThing = new Thing();
            clonedThing.Name = SelectedThing.Name + " - copy";
            clonedThing.Price = SelectedThing.Price;
            Things.Add(clonedThing);
            SelectedThing = clonedThing;
        }
        public void DeleteItem()
        {
            Thing tempThing = new Thing();
            tempThing = SelectedThing;
            if (Things.IndexOf(SelectedThing) != 0)
            {
                SelectedThing = Things.FirstOrDefault();
            }
            else if (Things.Count==1)
            {
                SelectedThing = null;
            }
            else
            {
                SelectedThing = Things[1];
            }
            Things.Remove(tempThing);
        }
    }
