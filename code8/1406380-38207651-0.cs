    //Error Checking Logic
    SpinWait spinner = new SpinWait();
            while (!condition())
            {
                //Timeout checks
                spinner.SpinOnce();
                //Timeout and Yielding checks
                }
            }
    //Return Logic
