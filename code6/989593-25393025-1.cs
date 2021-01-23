    public partial class ListDialogBox : Window, INotifyPropertyChanged
    {   
        /* The DataContext of the ListDialogBox is itself.  It implements
         * INotifyPropertyChanged so that the dialog box bindings are updated when
         * the caller modifies the functionality.
         */
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        /* Optionally, the ListDialogBox provides a callback mechanism that allows
         * the caller to cancel the removal of any of the items.
         * See usage for more details.
         */
        public event RemoveItemEventHandler RemoveItem;
        protected void RaiseRemoveItem(RemoveItemEventArgs args)
        {
            if (RemoveItem != null)
            {
                RemoveItem(this, args);
            }
        }
        //Local copies of all the properties. (with default values)
        private string prompt = "Select an item from the list.";
        private string selectText = "Select";
        private bool canRemoveItems = false;
        private ObservableCollection<INamedItem> items;
        private INamedItem selectedItem = null;
        public ListDialogBox()
        {
            InitializeComponent();
            DataContext = this;  //The DataContext is itself.
        }
        /* Handles when an item is double-clicked.
         * The ListDialogBox.SelectedItem property is set and the dialog is closed.
         */
        private void LstItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SelectedItem = ((FrameworkElement)sender).DataContext as INamedItem;
            Close();
        }
        /* Handles when the confirm selection button is pressed.
         * The ListDialogBox.SelectedItem property is set and the dialog is closed.
         */        
        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            SelectedItem = LstItems.SelectedItem as INamedItem;
            Close();
        }
        
        /* Handles when the cancel button is pressed.
         * The lsitDialogBox.SelectedItem remains null, and the dialog is closed.
         */
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        /* Handles when any key is pressed.  Here we determine when the user presses
         * the ESC key.  If that happens, the result is the same as cancelling.
         */
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {   //If the user presses escape, close this window.
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }
        /* Handles when the 'x' button is pressed on any of the items.
         * The item in question is found and the RemoveItem event subscribers are notified.
         * If the subscribers do not cancel the event, then the item is removed.
         */
        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {   //Obtain the item that corresponds to the remove button that was clicked.
            INamedItem removeItem = ((FrameworkElement)sender).DataContext as INamedItem;
            RemoveItemEventArgs args = new RemoveItemEventArgs(removeItem);
            RaiseRemoveItem(args);
            if (!args.Cancel)
            {   //If not cancelled, then remove the item.
                items.Remove(removeItem);
            }
        }
        //Below are the customizable properties.
        /* This property specifies the prompt that displays at the top of the dialog. */
        public string Prompt
        {
            get { return prompt; }
            set
            {
                if (prompt != value)
                {
                    prompt = value;
                    RaisePropertyChanged("Prompt");
                }
            }
        }
        /* This property specifies the text on the confirm selection button. */
        public string SelectText
        {
            get { return selectText; }
            set
            {
                if (selectText != value)
                {
                    selectText = value;
                    RaisePropertyChanged("SelectText");
                }
            }
        }
        /* This property controls whether or not items can be removed.
         * If set to true, the the 'x' button appears on the ItemTemplate.
         */
        public bool CanRemoveItems
        {
            get { return canRemoveItems; }
            set
            {
                if (canRemoveItems != value)
                {
                    canRemoveItems = value;
                    RaisePropertyChanged("CanRemoveItems");
                }
            }
        }
        /* This property specifies the collection of items that the user can select from.
         * Note that this uses the INamedItem interface.  The caller must comply with that
         * interface in order to use the ListDialogBox.
         */
        public ObservableCollection<INamedItem> Items
        {
            get { return items; }
            set
            {
                items = value;
                RaisePropertyChanged("Items");
            }
        }
        //Below are the read only properties that the caller uses after
        //prompting for a selection.
        /* This property contains either the selected INamedItem, or null if
         * no selection is made.
         */
        public INamedItem SelectedItem
        {
            get { return selectedItem; }
            private set
            {
                selectedItem = value;
            }
        }
        /* This property indicates if a selection was made.
         * The caller should check this property before trying to use the selected item.
         */
        public bool IsCancelled
        {   //A simple null-check is performed (the caller can do this too).
            get { return (SelectedItem == null); }
        }
    }
    //This delegate defines the callback signature for the RemoveItem event.
    public delegate void RemoveItemEventHandler(object sender, RemoveItemEventArgs e);
    /* This class defines the event arguments for the RemoveItem event.
     * It provides access to the item being removed and allows the event to be cancelled.
     */  
    public class RemoveItemEventArgs
    {
        public RemoveItemEventArgs(INamedItem item)
        {
            RemoveItem = item;
        }
        public INamedItem RemoveItem { get; private set; }
        public bool Cancel { get; set; }
    }
