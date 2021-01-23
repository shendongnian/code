    string line;
    do {
        try {
            line = sr.ReadLine();
            // Do some work here
        }
        catch(System.IO.IOException) {
            break; 
        }
    } while(line != null);
