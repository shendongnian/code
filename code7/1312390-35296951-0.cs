    List<Button> buttonList = new List<Button>();
    
    buttonList.Add(btn1);
    .
    ..
    ...
    ..
    buttonList.Add(btn9);
    
    vsr result  = buttonList.All(x=>x.Text!=string.Empty);
    
    if(result)
    MessageBox.Show("The game is a draw");
