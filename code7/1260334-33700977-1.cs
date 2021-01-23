        int n1, n2, n3, n4;
        if (numbox1.Text == "" || numbox2.Text == "" || numbox3.Text == "" || numbox4.Text == "")
        {
            MessageBox.Show("el ip fadi");
        }
        else 
        {
           n1 = Convert.ToInt16(numbox1.Text);
           n2 = Convert.ToInt16(numbox2.Text);
           n3 = Convert.ToInt16(numbox3.Text);
           n4 = Convert.ToInt16(numbox4.Text);
        }
