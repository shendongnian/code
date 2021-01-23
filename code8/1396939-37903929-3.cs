        double medcharges;
        double surgcharges;
        double labcharges;
        double phyrehab;
        double totalMiscCharges;
        double totaldailycharges;
        double TotalCharges
        .
        .
        .
        public void CalcStayCharges()
        {
            try
            {
                double numofdays = Convert.ToDouble(txtdays.Text);
                totaldailycharges = (double)dailycharges * numofdays;
            }
            catch { }
        }
        public void CalcMiscCharges()
        {
            try
            {
                medcharges = Convert.ToDouble(txtmedicalfee.Text);
                surgcharges = Convert.ToDouble(txtsurgicalfee.Text);
                labcharges = Convert.ToDouble(txtlabfee.Text);
                phyrehab = Convert.ToDouble(txtrehabfee.Text);
                totalMiscCharges = medcharges + surgcharges + labcharges + phyrehab;
            }
            catch { }
        }
        public void CalcTotalCharges()
        {
            TotalCharges = totaldailycharges + totalMiscCharges;
        }
        public void BtnResult_Click(object sender, RoutedEventArgs e)
        {
            CalcStayCharges();
            CalcMiscCharges();
            CalcTotalCharges();``
            lbloutput.Text = "Your total charges are: " + TotalCharges.ToString("C");
        }  
