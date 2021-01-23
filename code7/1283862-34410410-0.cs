    protected void Button9_Click(object sender, EventArgs e)
        {
           // this.TextBoxStartDate ="dd-MM-yyyy";
            DateTime dtval = DateTime.ParseExact(TextBoxStartDate.Text, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None);
            //Add values here
            DateTime formatteddays = dtval.AddDays(Int16.Parse(TextBoxPredictDays.Text));
            TextBoxPredictedClosing.Text = formatteddays.ToString("dd-MM-yyyy");
        }
