    public MyForm()
    {
        InitializeComponent();
    }
    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        Reload();
    }
    private void Reload()
    {
        // add/populate the rows here
        if(dgv.Rows.Count > 0)
        {
            dgv.Rows[dgv.Rows.Count - 1].Selected = true;
        }
    }
