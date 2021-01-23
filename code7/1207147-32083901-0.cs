    public void FillPH()
        {
            var MyList = new List<ListItem>
            {
                new ListItem("One", "1"),
                new ListItem("Two", "2"),
                new ListItem("Three", "3")
            };
            Table myTable = new Table();
            foreach (var item in MyList)
            {
                //Create new checkbox
                CheckBox CB = new CheckBox();
                CB.Text = item.Text;
                CB.ID = item.Value;
                //Create tablr row and td, then adds them accordignly
                TableRow TR = new TableRow();
                TableCell TD = new TableCell();
                TD.Controls.Add(CB);
                TR.Controls.Add(TD);
                //IF <YOUR FLAG GOES HERE>-->
                if (item.Value == "2")
                {
                    //Create your input element and place it in a new Table cell (TD2)
                    TextBox TB = new TextBox();
                    TB.ID = string.Format("tb_{0}", item.Value);
                    TableCell TD2 = new TableCell();
                    TD2.Controls.Add(TB);
                    TR.Controls.Add(TD2);
                }
                myTable.Controls.Add(TR);
            }
            fillMe.Controls.Add(myTable);
        }
