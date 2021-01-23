	int mod(int i, int m) { return ((i % m) + m) % m; }
    
    // Set this to 0 inside of Start()
    int startIndex;
    
    public void SimpleMov (){
        //added an i here
        int positionIndex = startIndex;
        for (int i = 0 ; i < degrau.Length ; i++) 
        {
            positionIndex++;
            degrau[i].transform.position = positionArray [mod(positionIndex, positionArray.Length)]
        }
        startIndex++;
    }
