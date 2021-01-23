    int n1, n2, n3, n4;
    if (!Int32.TryParse(numbox1.Text, out n1) || !Int32.TryParse(numbox2.Text, out n2) || 
        !Int32.TryParse(numbox3.Text, out n3) || !Int32.TryParse(numbox4.Text, out n4))
    {
        MessageBox.Show("el ip fadi");
        return;
    }
