    private async void button1_Click(object sender, EventArgs e)
    {
        System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
        stringBuilder.AppendLine("Name: " + txtName.Text);
        stringBuilder.AppendLine("Address: " + txtAddress.Text);
        stringBuilder.AppendLine("Phone: " + txtPhone.Text);
        stringBuilder.AppendLine("Blood Type: " + cmbBloodType.SelectedItem.ToString());
        System.IO.File.AppendAllText(@"C:\Users\Ben\Documents\C#\Final\Bloodbank\BloodBank\bin\Debug\Bloodbank.txt", stringBuilder.ToString() + Environment.NewLine);
    }
