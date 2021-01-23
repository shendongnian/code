    private void Calculate()
    {
      if(string.IsNullOrEmpty(rBox_1.Text) ||
         string.IsNullOrEmpty(rBox_2.Text) || 
         string.IsNullOrEmpty(rBox_3.Text))
        return;
      var box1 = GetNumber(rBox_1.Text);
      var box2 = GetNumber(rBox_2.Text);
      var box3 = GetNumber(rBox_3.Text);
      rBox_4.Text = ((box1 + box2 + box3)/3).ToString();
    }
