    public void Process() { 
        //init
        int startFrom = 0;
        int stepCount = 100;
        //read data  0 - 100
        ReadLines(startFrom, stepCount);
        startFrom += stepCount;
        // after user action
        //read data  100 - 200
        ReadLines(startFrom, stepCount);
    }
    public void ReadLines( int skipFirstNum, int readNum ) {
        using (StreamReader rdr = new StreamReader(cmd.OutputStream)) {
            // skip lines
            for (int i = 0; i < skipFirstNum; i++) { 
                 rdr.ReadLine();  
            }
            for (int i = 0; i < readNum ; i++) { 
                 // ... these are the lines to process
            }
        }
    }
