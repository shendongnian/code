    public void ShowPopup(int appID)
    {
        DataTable dtGetID = AppData.GetID(appID);
        if (dtGetID.Rows.Count > 0)
        {
            lblAppID.Text = dtGetID.Rows[0]["Id"].ToString();
            lblAppName.Text = dtGetID.Rows[0]["Name"].ToString();               
            popup.Show();
            upPopup.Update();
        }
    }
