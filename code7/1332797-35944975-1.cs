    public async void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
      Astrometry ast = new Astrometry();
      await ast.OnlineSolve(GlobalVariables.SolveImage);
    }
