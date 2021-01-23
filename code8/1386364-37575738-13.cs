    List<Information> list = new List<Information>();
    int currentForm = 0;
    private void btnBack_Click(object sender, EventArgs e)
    {
        try
        {
            SaveCurrentInfo();
            currentForm--;
            ClearForm();
            Information info = list[currentForm];
            txtUsername.Text = info.Username;
            txtWorkstation.Text = info.Workstation;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    
    private void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
            SaveCurrentInfo();
            currentForm++;
            ClearForm();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
    private void SaveForm()
    {
        Information info = new Information();
        info.Username = txtUsername.Text;
        info.Workstation = txtWorkstation.Text;
        // ...etc
        if (currentForm < list.Count)
        {
            list[currentForm] = info;
        }
        else
        {
            list.Add(info);
        }
    }
    private void ClearForm()
    {
        txtUsername.Text = string.Empty;
        txtWorkstation.Text = string.Empty;
        btnBack.Enabled = currentForm > 0;
    }
