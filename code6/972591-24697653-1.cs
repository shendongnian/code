    class FaderControl
    {
       bool _hasFadedIn=false;
       public void Update(int totalMilliseconds)
       {
           if (_hasFadedIn)
                return;
           if (totalMilliseconds <= 2000)
                return;
           this.Fader.FadeIn();
           _hasFadedIn=true;
       }
    }
