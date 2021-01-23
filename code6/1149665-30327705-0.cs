    void myForm_MouseMoved(object sender, MouseEventArgs e)
    {
        MoveCharacter(e.X, e.Y);
    }
    
    void myForm_SomethingElseHappened(object sender, EventArgs e)
    {
        if(IsCharacterTooLow()) 
        {            
            MoveCharacter(_currentPos.X, _currentPos.Y+20)
        }
    }
