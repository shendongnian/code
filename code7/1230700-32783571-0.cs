    private static int correct = 0;
    public ActionResult Intermediate()
    {
        if (correct != GameInfo.correct)
        {
            correct = GameInfo.correct;
            GameInfo.roundcounter++;
        }
        return View(); 
    }
