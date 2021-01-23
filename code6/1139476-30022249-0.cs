    private void _gvDoctorVisit_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        int visitid = ((dynamic)_gvDoctorVisit.SelectedItem).visit_id;
        MessageBox.Show(visitid.ToString());
    }
