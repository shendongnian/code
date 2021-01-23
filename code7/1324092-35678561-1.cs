    //Enter  Names up to 100 and store them in array
    private void btnEnterName_Click(object sender, EventArgs e)
    {
        bool nameExist = !string.IsNullOrEmpty(txtName.Text);
        bool notHittingMaxName = index < names.Length;
        if (nameExist && notHittingMaxName)
        {
            names[index++] += txtName.Text;
            txtName.Clear();
        }
        else
        {
            // array 'full' or empty name
        }
    }
