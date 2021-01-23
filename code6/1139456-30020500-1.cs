    public void btnRaiseEvent_Clicked(object sender, EventArgs e)
    {
       var fact= txtFact.Text;
       var handler = SomethingInterestingHappened;
       if (handler!=null)
       {
          handler(this,new InterestingEventArgs(fact));
       }
    }
