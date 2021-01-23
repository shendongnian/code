    public void Save(Form1 f)
    {
        if(f.gameList.SelectedItems.Count == 1)
        {
            f.Game[f.gameList.SelectedItems[0].Index].gametitle = f.titleText.Text;
            f.Game[f.gameList.SelectedItems[0].Index].developer = f.developerText.Text;
            f.Game[f.gameList.SelectedItems[0].Index].publisher = f.publisherText.Text;
            f.Game[f.gameList.SelectedItems[0].Index].platform = f.platformCheckBox.CheckedItems.ToString();
        }
    }
