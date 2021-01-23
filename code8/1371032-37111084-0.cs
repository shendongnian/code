    public class External{
        ListBox list;
        public External(){
            list= ListContainer.PeogramListBox;
              list.SelectedIndexChanged+=listItemSelectionChanged;
        }
        void listItemSelectionChanged(object sender, EventArgs e)
        {
            // read selected inddex and remove item.
        }
    }
