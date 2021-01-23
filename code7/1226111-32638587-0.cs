    private void textBox_TextChanged(object sender, EventArgs e){
         var thisBox = sender as TextBox;
         //given name like "textBox1a"
         var boxNumber = thisBox.Name.SubString(7,1);
         var boxLetter = thisBox.Name.SubString(8,1);
         //numbers (horizontal?)
         for(int i = 1; i<=9; i++){
              if(i.ToString() == boxNumber)
                   continue; //don't compare to self
              var otherBox = Page.FindControl("textBox" + i + boxLetter) as TextBox;
              if (otherBox.Text == thisBox.Text)
              {
                   thisBox.BackColor = System.Drawing.Color.Red;
                   otherBox.BackColor = System.Drawing.Color.Red;
              }
         }
         //letters (vertical?)
         for(int i = 1; i<=9; i++){
              var j = ConvertNumberToLetter(i); //up to you how to do this
              if(j == boxLetter)
                   continue; //don't compare to self
              var otherBox = Page.FindControl("textBox" + boxNumber + j) as TextBox;
              if (otherBox.Text == thisBox.Text)
              {
                   thisBox.BackColor = System.Drawing.Color.Red;
                   otherBox.BackColor = System.Drawing.Color.Red;
              }
         }
    }
