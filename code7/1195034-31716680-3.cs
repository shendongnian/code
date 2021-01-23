    private void comboFindState_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboFindState.SelectedValue != null)
        {
            int selectedStateId = (int)comboFindState.SelectedValue;
            DataTable citiesTable = DatabaseHelper.getStateCities(selectedStateId);
            //Your code after getting list of the cities
        }
    }
