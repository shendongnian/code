    public void process_data(string output_filepath, bool debug=false)
        {
            debug = true; // manual override for debugging
    System.IO.StreamWriter debug_file;
            if (debug == true)
            {
                debug_file = new System.IO.StreamWriter(output_filepath);
            }
    
            for (int i=1; i<10; i++)
            {
                // do some other stuff     
                if (debug == true)
                {
                    debug_file.WriteLine("output something: " + i);
                }
            }
    
            // do some other stuff
    
            if (debug == true)
            {
                debug_file.Close();
            }
        }
