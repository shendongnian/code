    public ProjectForm(TreeView catView)
    {
        InitializeComponent();
        holalala = catView;
    }
    
    public void AddComboBox()
    {
        int i;
        if (holalala != null)
        {
            i = holalala.Nodes.Count;
            if (i != 0)
            {
                var newone2 = new DataGridViewComboBoxColumn();
                newone2.HeaderText = "Main category";
                newone2.Name = "ColNr_" + nofCols;
                string comboTxt;
                for (int j = 0; j < i; j++)
                {
                    comboTxt = holalala.Nodes[j].Text;
                    newone2.Items.Add(comboTxt);
                }
                mainProjectGrid.Columns.Add(newone2);
                nofCols += 1;
            }
         }
    }
