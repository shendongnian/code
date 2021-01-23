      private async void button1_Click(object sender, EventArgs e)
      {
         double result;
         try
         {
            result = await Task.Run(() => this.SlowDivision(3, 0));
         }
         catch (ArgumentException ex)
         {
            // handle the exception here.
         }
         this.Label1.Text = result.ToString();
      }
      private double SlowDivision(double a, double b)
      {
         System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));
         if (b == 0) throw new ArgumentException("b");
         return a / b;
      }
