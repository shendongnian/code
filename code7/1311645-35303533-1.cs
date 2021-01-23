        gvContributors.DataSource = bookContributors; //set the datgridview's datasource so it displays the class you want.
        gvContributors.Columns["BookContributorType"].Visible = false; //hide the column (property) you want to replace with a combobox.
        DataGridViewComboBoxColumn contribType = new DataGridViewComboBoxColumn(); //create a combobox object.
        contribType.HeaderText = "My Column"; //the text to display in the column header.
        contribType.Name = "BookContributorType"; //name of the class property you set to Visible=false. Note sure if this is needed.
        contribType.DataSource = bookContributorTypes; //name of the class that provides the combobox data.
        contribType.DisplayMember = "BookContributorTypeDescription"; //data the user will see when clicking the combobox.
        contribType.ValueMember = "BookContributorTypeId"; //data to store in the class property.
        contribType.DataPropertyName = "BookContributorType"; //the class property you are binding to in order to store the data.
        gvContributors.Columns.Add(contribType); //add the new combobox to the datagridview.
