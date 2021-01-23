        btnBMI.Click += (object sender, EventArgs e) =>
        {
           intuserweight = int.Parse(userWeight.Text.ToString());
           intuserheight = int.Parse(userHeight.Text.ToString());
        bmi = intuserweight / (intuserheight * intuserheight);
            string toast = string.Format("Your BMI is:  ", bmi);
            Toast.MakeText(this, toast, ToastLength.Long).Show();
        };
