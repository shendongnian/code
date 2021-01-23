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
                //  OnClicked(string strr);///error here!!!!!!!!!!!!!!!!
            }
        }
       }
       //register the event 
         OnClickedE += new ColourChangerAction(OnGUI);
