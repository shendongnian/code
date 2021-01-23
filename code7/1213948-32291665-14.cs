    var checkedIndices = this.checkedListBox1.CheckedIndices.Cast<int>().ToList();
    if (e.NewValue == CheckState.Checked)
        checkedIndices.Add(e.Index);
    else
        if(checkedIndices.Contains(e.Index))
            checkedIndices.Remove(e.Index);
     //now you can do what you need to checkedIndices
     //Here if after check but you should use the local variable checkedIndices 
     //to find checked indices
