    foreach(char ch in txfanrpm.Text)
    {
         if (!Char.IsDigit(ch))
         {
              MessageBox.Show(ch + " is not numeric");
              continue;
         }
         actualdata += ch;
    }
