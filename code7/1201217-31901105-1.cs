    for (i = 1; i <= 18; i++)
    {
    ButtonSelect[i] = new Button();
    ButtonSelect[i].BackgroundImage = Properties.Resources.SelectImages[i];
    ButtonSelect[i].MouseEnter += new System.EventHandler(Btn_MouseEnter); 
    ButtonSelect[i].MouseLeave += new System.EventHandler(Btn_MouseLeave); 
    }
