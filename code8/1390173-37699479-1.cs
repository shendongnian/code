    pulic void MyFunc() 
    {
        // do stuff here in the scope of MyFunc
        {
            // create child scope with new scoping rules and declare control variables
            var fooTrue = foo == true;
            var barFalse = bar== false;
            if (fooTrue || barFalse)
            {
                if (fooTrue)
                {
                    //foo is true
                }
                if (barFalse)
                {
                    //bar is false
                }
            }
        }
       // stuff here cannot access fooTrue, barFalse.
    }
