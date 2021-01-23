    protected void btn1_Click(object sender, EventArgs e)
            {
                datagrid_1.Visibility = Visibility.Visible;
                datagrid_2.Visibility = Visibility.Collapsed;
                datagrid_3.Visibility = Visibility.Collapsed;
                lblPageHeader.Text = "datagrid_1 is selected";
            }
