    public class ListItem
    {
        public override string ToString()
        {
            return this.id.ToString();
        }
    }
    private void lstWeapons1_SelectedIndexChange(object sender, EventArgs e)
    {
        if(lstWeapons1.SelectedItem != null) 
        {
           var text = lstWeapons1.SelectedItem.ToString();
        }
    }
