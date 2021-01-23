    int num;
    if(!Int32.TryParse(txtFrom.Text, out num))
    {
      MessageBox.Show("Not a valid number");
      return;
    }
    txtTo.Text = (num + listViewItem1.Items.Count).ToString();
