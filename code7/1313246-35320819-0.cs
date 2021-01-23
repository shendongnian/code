    var f2 as new Form2();
    //fill the firstValue propery with the 3rd column of the listview 
    f2.firstValue = listview1.FocusedItem.SubItems[2].Text;
    //fill the secondValue property with the 4th column of the listview
    f2.secondValue = listview1.FocusedItem.SubItems[3].Text;
    //show f2 as a dialog
    DialogResult ans = f2.ShowDialog();
    if(ans == DialogResult.OK)
    {
        //update the listview with the values from the properties of form2
        listview1.focusedItem.SubItems[2].Text = f2.firstValue;
        listview1.FocusedItem.SubItems[3].Text = f2.secondValue;
    }
