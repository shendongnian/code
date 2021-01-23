    private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
           var block = sender as TextBlock;
    	   block.FontSize = 90;
        }
    private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
          var block = sender as TextBlock;
          block.FontSize = 72;
        }
 
