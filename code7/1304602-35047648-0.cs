    public void MyComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch(MyComboBox.SelectedIndex)
        {
            case 0:
                MyFrame.Content = new MyPage1();
                break;
            case 1:
                MyFrame.Content = new MyPage2();
                break;
        }
    }
 
