    private void computeTotal()
    {
        tenpesos = (int)tenpeso.Value * 10;
        fivepesos = (int)fivepeso.Value * 5;
        onepesos = (int)onepeso.Value * 1;
        twofivecents = (int)twofivecent.Value * .25;
        tencents = (int)tencent.Value * .10;
        fivecents = (int)fivecent.Value * .05;
        total = tenpesos + fivepesos + onepesos + twofivecents + tencents
            + fivecents;
        totalText.Text = Convert.ToString(total);
        var fileRepository = new FileRepository();
        fileRepository.AddMoney((decimal)total);
    }
