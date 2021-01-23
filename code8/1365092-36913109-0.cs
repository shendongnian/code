    private void button1_Click(object sender, EventArgs e)
     {
         Person p;
         if (rbtnNormalTimer.Checked)
         {
           p= new Person(TypeTimer.Unlimited)
         }
         else if (rbtnCountDown.Checked)
         {
            p= new Person(TypeTimer.Countdown)
         }
         else if (rbtnLimited.Checked)
         {
            p= new Person(TypeTimer.Limited)
         }
      // proceed with p
     }
