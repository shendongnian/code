    private String[] _Tags;
    public frmSaveQuery(string Name, 
                        string Description, 
                        string tagList, 
                        List<TagType> AllTags)
    {
        InitializeComponent();
        TagList = AllTags;
        Cancelled = true;
        txtQueryName.Text = Name;
        txtDescription.Text = Description;
        //Save tags in the class variable
        _Tags = tagList.Split(new string[] {"|"}, StringSplitOptions.RemoveEmptyEntries);
        //Wiring up handler to the event
        this.Shown += frmSaveQuery_Shown;
    }
    public void frmSaveQuery_Shown(Object sender, EventArgs e)
    {
        if (_Tags == null || _Tags.Length == 0)
            return;
        foreach (DataGridViewRow row in tagSelector.Rows)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (tags.Contains(cell.Value.ToString().ToUpper()))
                {
                    cell.Selected = true;
                }
                else
                {
                    cell.Selected = false;
                }
            }
        }
        foreach (DataGridViewRow row in tagSelector.Rows)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (cell.Selected) Debug.WriteLine (cell.Value.ToString());
            }
        }
    }
