    public class UninstallItem{
       public UninstallItem{}
        
       public void RemoveSelected(ListBox list)
        {
            if(list.SelectedIndex==-1)
            {
                MessageBox.Show("Please Select Item from List");
                return;
            }
            list.Items.RemoveAt(list.SelectedIndex);
            
        }
    }
