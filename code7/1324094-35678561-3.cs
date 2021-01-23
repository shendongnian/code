    //Enter  Names up to 100 and store them in array
    private void btnEnterName_Click(object sender, EventArgs e)
    {
        // remove spaces at start and end
        string trimedName = txtName.Trim();
        bool nameExist = !string.IsNullOrEmpty(trimedName);
        bool notHittingMaxName = index < names.Length;
        if (nameExist && notHittingMaxName)
        {
            names[index++] += trimedName;
            txtName.Clear();
        }
        else
        {
            // array 'full' or empty name
        }
    }
