    public void OnGUI(){
        float width = 75;
        float height = 75;
    
        for (int y= 0; y < 3; y++) {
            for (int x= 0; x < 3; x++) {
                int boardIndex = (y*3)+x;
                Rect square = new Rect(x *width, y*height, width, height); 
                string owner = board[boardIndex]
                == SquareState.XControl ? "X" : board[boardIndex] == SquareState.OControl ? "O" : ""; 
                if (GUI.Button(square,owner))
                    setControl(boardIndex);
            }
        }
    }
