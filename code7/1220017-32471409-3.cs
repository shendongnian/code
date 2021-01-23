    //Defining Delegate and event
    public delegate void ColourChangerAction(string str);
    public static event ColourChangerAction OnClickedE;
    // Method signature for subscribe the event
       static void OnGUI(string str)
       {
        if (1 == 1)
        {
            if (OnClickedE != null)
            {
               // perform your action here
            }
        }
       }
    //register the event 
    OnClickedE += new ColourChangerAction(OnGUI);
    // Invoke the event dynamically
     OnClickedE.DynamicInvoke("Some string");
