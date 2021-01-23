    static int[] preto = new int[] { 2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 22, 24, 26, 28, 29, 31, 33, 35 };
    static int[] vermelho = new int[] { 1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21, 23, 25, 27, 30, 32, 34, 36 };
    int number = Convert.ToInt32(lbl_random.Text);
    if (number == 0)
    {
       lstZeros.Items.Insert(0, "0");
       lstVermelhos.Items.Insert(0, "");
       lstPretos.Items.Insert(0, "");
    }
    else if (preto.Contains(number))
    {
       lstZeros.Items.Insert(0, "");
       lstVermelhos.Items.Insert(0, "");
       lstPretos.Items.Insert(0, number.ToString());
    }
    else 
    {
       // then is a black....
       lstZeros.Items.Insert(0, "");
       lstVermelhos.Items.Insert(0, number.ToString());
       lstPretos.Items.Insert(0, "");
    }
