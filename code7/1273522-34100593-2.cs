    public void PlayGames ()
    {
        String replay = "";
        var a = PlayBlackjack (r, replay);
        Console.WriteLine ();
        while (a == "yes") {
            a = PlayBlackjack (r, replay);
            if (a == "no") {
                Console.WriteLine ("Okay, goodbye!");
                return;
            }
        }
        //Do nothing, the while in Main function will already take us back to the menu
    }
