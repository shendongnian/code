    // If the reading from the database gives always the same value is not correct to 
    // exexute this code inside the foreach. Just do it one time here and go on....
    float classRPM = 0.0f;
    using (Fanrpm ds = new Fanrpm(cbdesigntype.SelectedValue.ToString(),
                                  cbfansize.SelectedValue.ToString(), 
                                  cbfanclass.SelectedValue.ToString()))
    {
         DataTable dt = ds.dataset.Tables[0];
         classRPM = dt.Rows[0].Field<float>("ClassRPM");
    }
    float fanRPM;
    string actualdata = string.Empty;
    // No need to use AsEnumerable.... 
    // And also this code could be easily replaced by single line float.TryParse 
    // if you don't need to show a message box for every wrong char....
    foreach (char aChar in txfanrpm.Text.ToCharArray())
    {
        if (Char.IsDigit(aChar))
            actualdata = actualdata + aChar;
        else
            MessageBox.Show(aChar + " is not numeric");
    }
    // Now you could start your comparisons....
    fanRPM = Convert.ToSingle(actualdata);
    if (fanRPM >= classRPM)
       MessageBox.Show("hi");
    else
       MessageBox.Show("Hide");
