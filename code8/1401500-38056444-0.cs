    protected void chklstOptions_SelectedIndexChanged(object sender, EventArgs e)
        {            
            var selectedItem = chklstOptions.SelectedItem;   
            string result = Request.Form["__EVENTTARGET"];
            string[] checkedBox = result.Split('$'); ;
            int index = int.Parse(checkedBox[checkedBox.Length - 1]);
            string latestItem = chklstOptions.Items[index].Value;
            foreach (ListItem Item in chklstOptions.Items)
            {
                if (Item.Selected)
                {
                    if (Item.Text == "RepOptionA" && latestItem == "RepOptionB")
                    {                    
                            chklstOptions.Items.FindByText("RepOptionA").Selected = false;
                            chklstOptions.Items.FindByText("RepOptionB").Selected = true;
                    }
                    if (Item.Text == "RepOptionB" && latestItem == "RepOptionA") 
                    {
                        chklstOptions.Items.FindByText("RepOptionB").Selected = false;
                        chklstOptions.Items.FindByText("RepOptionA").Selected = true;
                    }              
                }
            }
        }
