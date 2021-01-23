    for (int i = 1; i < 100; i++)
    {
         for (int j = i; j < 100; j++)
         {
               //select numbers wich sum is dividing on 4
               if( (i+j)%4 == 0)
               {
                     label3.Text += Convert.ToString(i) + Convert.ToString(j) " | ";
               }
         }
    }
