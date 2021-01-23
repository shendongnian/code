    string txtName = string.Empty;
    int[,] aVal = new int[10, 10];
    for (int i = 0; i < 10; i++)
    {
       for (int x = 0; x < 10; x++)
       {
          txtName = String.Format("txt_{0}_{1}", i, x);
          string sVal = ((TextBox)this.Controls[txtName]).Text
          int iVal = 0;
          if (int.TryParse(sVal, out iVal))
              aVal[i][x] = iVal;
       }
    }
