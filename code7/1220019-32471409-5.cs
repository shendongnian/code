    //Defining Delegate and event
    public delegate void ColourChangerAction(string str);
    public static event ColourChangerAction OnClicked;
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
    OnClicked += new ColourChangerAction(OnGUI);
    // Invoke the event dynamically
     OnClicked.DynamicInvoke("Some string");
