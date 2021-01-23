    private void buttonClear_Click(object sender, EventArgs e)
    {
        allPointLists.Clear();
        Invalidate();
    }
    private void buttonUndo_Click(object sender, EventArgs e)
    {
        allPointLists.Remove(allPointLists.Last());
        Invalidate();
    }
