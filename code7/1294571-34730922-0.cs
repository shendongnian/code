    public void AddToScore(int points)
    {
        score += points;
        if (score >= bonusTarget)
        {
            bonusTarget += 2000;
            paddle.Bonus();
        }
    }
