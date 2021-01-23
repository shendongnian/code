    bool[,] cells = obj.GetCells();
    for(int i = 0; i <= cells.GetUpperBound(0); i++) {
        for(int j = 0; j <= cells.GetUpperBound(1); j++) {
            // Do something with cells[i,j] 
        }
    }
