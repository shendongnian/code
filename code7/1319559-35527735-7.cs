    DateTime currentTick = DateTime.Min;
    DateTime startTick = DateTime.Min;
    private void timer1_Tick(object sender, EventArgs e)
    {
        currentTick = DateTime.Now;
        if ((currentTick - startTick).TotalSeconds / 100 < delayIn10Ms)
            pictureBox1.Image = gifImage.GetNextFrame();
        else
            timer1.Stop(); //stop the timer        
    }
    //And somewhere else you have
    timer1.Start(); //to start the timer
    int x = rollDice(); //Here I roll the dice
    
    switch (x){
         case 1: dice.Image = resources.diceFace1; //Image set depending on x
                 break
         case 2: //etc...
    }
