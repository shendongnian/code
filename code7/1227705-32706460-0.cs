    public class Item
    {
    .
    .
    .
        //method that will set the ItemIndex to the current index
        public void UpdateIndex(int index)
        {
            this.ItemIndex = index;
            if (this.ItemsList != null)
            {
                this.ItemsList = this.ItemsList.Select((x,index) => x.UpdateIndex(index+1)).ToList();
            }
        }   
    }
