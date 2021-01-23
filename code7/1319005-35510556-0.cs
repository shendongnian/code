    public void YourCodeModifiedForDecimal()
    {
    int a = Int32.Parse(tb_weight.Text);
    decimal b = 0;
    b = (a* 1.03m) / 1000m;
    decimal g = 0;
    g = (1.09m + (0.41m * (Sqrt(50m / b))));
    lbl_vertforce.Content = Math.Round((b* g * 9.81m), 2);
    }
    public static decimal Sqrt(decimal x, decimal? guess = null)
    {
        var ourGuess = guess.GetValueOrDefault(x / 2m);
        var result = x / ourGuess;
        var average = (ourGuess + result) / 2m;
        if (average == ourGuess) // This checks for the maximum precision possible with a decimal.
            return average;
        else
            return Sqrt(x, average);
    }
