    public void timer_personnage_chute_event(object sender, ElapsedEventArgs e)
    {
        bool result = perso.Dispatcher.Invoke( // Dispatcher pour utiliser le multithearding
            () =>
            {
                perso.Chuter();
                return perso.WorlFarmeCollision();
            }
            , DispatcherPriority.Normal);
