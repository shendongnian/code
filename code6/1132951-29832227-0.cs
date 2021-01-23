        ....
        else if (e.KeyCode == Keys.Right)
        {
            checkIfMoved = false;
            .... a lot of code
            if (checkIfMoved == true)
            {
                GenerateField();
            }  
        }// <-- here
        else if (e.KeyCode == Keys.Up)
        {
           ...
