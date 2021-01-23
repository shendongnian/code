    int num1 = 0; int i = 0; int j = 0; int h = 0;
    for (int k = 0; k <= ListView1.Items.Count - 1; k++)
    {
      i = Convert.ToInt32(ListView1.Items[k].SubItems[4].Text);  
    }
            
    int.TryParse(txtQtyKilo.Text, out j); 
    num1 = i + j;
    textBox11.Text = Convert.ToString(num1);
    int.TryParse(textBox11.Text, out h);
    if (num1 <= Convert.ToInt32(txtOnHand.Text))
    {
      textBox11.Text = "";
    }
    else
    {
      txtQtyKilo.Text = "";
      textBox11.Text = "";
      MessageBox.Show("Must not be greater than the available menu!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
