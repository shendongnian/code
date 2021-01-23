    var checkedIndices = this.checkedListBox1.CheckedIndices.Cast<int>().ToList();
    if (e.NewValue == CheckState.Checked)
        checkedIndices.Add(e.Index);
    else
        if(checkedIndices.Contains(e.Index))
            checkedIndices.Remove(e.Index);
