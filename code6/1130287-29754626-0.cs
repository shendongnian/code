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
    }`
