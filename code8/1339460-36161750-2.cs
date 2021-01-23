    public void Pause()
        {
            paused = !paused;
            if (paused)
            {
                Time.timeScale = 0;
            }
            else
            {
               Time.timeScale = 1;
            }
        }
