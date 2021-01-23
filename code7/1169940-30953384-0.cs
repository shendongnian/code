     Control nextControl; 
     if (e.KeyCode == Keys.Enter)
     {
    nextControl = GetNextControl(ActiveControl, !e.Shift);
    nextControl.Focus();
    if(nextControl=Combo)
    {
    KeyPreview=false;   
    }
    e.SuppressKeyPress = true;
    }
