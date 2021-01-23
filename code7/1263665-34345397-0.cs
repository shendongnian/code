    private void button1_Click(object sender, EventArgs e)
    {
      if (string.IsNullOrEmpty(txtCarPrice.Text))
          return;
      int carPrice = Convert.ToInt32(txtCarPrice.Text);
      double downPayment = carPrice * .2;
      txtDownPayment.Text = downPayment.ToString("0.#####");
    }   
     
