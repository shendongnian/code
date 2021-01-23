        List<Button> buttonList = new List<Button>()
    {
       btn1,
       btn2,
       ...
       btn9
    };
           
        vsr result  = buttonList.All(x=>x.Text!=string.Empty);
        
        if(result)
        MessageBox.Show("The game is a draw");
