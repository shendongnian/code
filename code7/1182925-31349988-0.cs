	int mod(int i, int m) { return ((i % m) + m) % m; }
    public void SimpleMov (){
        for (int i = 0 ; i < degrau.Length ; i++) 
        {
            degrau[i].transform.position = positionArray [mod(i + 1, positionArray.Length)]
        }
    }
