    void TrolloWorld(long currentUnixTime, long loopsPerMs){
        long laterUnixTime = 2051222400000;  //unix time of 01/01/2035, 00:00:00
        long numLoops = (laterUnixTime-currentUnixTime)*loopsPerMs;
        for (long i=0; i<numLoops; i++){
            print ("It's still not time to print the hello …");
        }
        print("Hello, World!");
    }
