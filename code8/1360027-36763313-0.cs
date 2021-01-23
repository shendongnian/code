    int bet = 1;
    bool increase=true;
    private void bttnAdd_Click(object sender, EventArgs e)
    {
       if(increase){
          bet++;
          lblBet.Text = "" + bet;
       }
       else{
           bet--;
           lblBet.Text = "" + bet;
       }
       if(bet==5 || bet==1)
       {
           increase=!increase;
       }
    }
