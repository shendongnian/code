    private async Task RunCoinFlipAsync()
    {
      ToggleControlsUsability();
      await CoinFlippingAnimationAsync();
      ToggleControlsUsability();
      flipOutcome = picCoin.Image == coinSideImages[0] ? CoinSides.Heads : CoinSides.Tails;
      lblResult.Text = userGuess == flipOutcome ? "Congrats you won!" : "Too bad you lost.";
    }
    private async Task CoinFlippingAnimationAsync()
    {
      Random rng = new Random();
      for (int i = 0; i < 15; i++)
      {
        int side = rng.Next(0, coinSideImages.Length);
        picCoin.Image = coinSideImages[side];
        await Task.Delay(100);
      }
    }
