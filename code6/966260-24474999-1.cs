     for (int i = 0; i < memberArray.Length; i++)
     {
      if (memberArray[i] == null)
      {
       memberArray[i] = new Member();
       memberArray[i].Name = TbName.Text;
       memberArray[i].Address = TbAddress.Text;
       MessageBox.Show(TbName.Text + " has been added as a subscriber.");
       break;
      }
     }
