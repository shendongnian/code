    private void button2_Click(object sender, EventArgs e)
    {
        if ((kennzeichen.Text != "") && (automarke.Text != ""))
        {
            car myCar = new car();
            myCar.addCar(kennzeichen.Text, automarke.Text);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
