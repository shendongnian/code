    // array of your buttons (it's not necessary)
    var buttons = new Button[4,4];
    
    void SomeMethod()
    {
        for(var x = 0; x < 4; x++)
        {
        for(var y = 0; y < 4; y++)
            {
                var newButton = new Button();
                // put your text into the button
                newButton.Text = board.gameBoard[x, y].getValue().ToString();
                // set the coordinates for your button
                newButton.Location = new Point(someCoordinateX, someCoordinateY);
            
                // store just created button to the array
                buttons[x, y] = newButton;
           
                // add just created button to the form
                this.Controls.Add(newButton).
            }
        }
    }
