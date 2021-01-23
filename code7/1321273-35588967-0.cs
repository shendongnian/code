    TableLayoutPanel[,] grid = new TableLayoutPanel[10, 10];
        int k=0,l=0;   
         foreach (TableLayoutPanel c in mainTPL.Controls)
                            {  
                                if(k<10 && l<10)
                                {
                                     grid[k, l] = c;
                                     if (l != 9)
                                         l++;
                                     else
                                     {
                                            l = 0;
                                            k++;
                                     }
                                }
                            }
