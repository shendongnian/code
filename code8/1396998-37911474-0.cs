    TextBox txt;
    static int i = 0;
    protected void Button1_Click(object sender, EventArgs e)
    {
        if(i%2==0)
        {
            for (int j = 0; j < 3; j++)
            {
                txt= new TextBox();
                txt.Height = 25;
                txt.Width = 150;
                txt.Font.Size = 10;
                txt.ID = j.ToString();
                PlaceHolder1.Controls.Add(txt);
             }
         }
         i++;                                           
    }
