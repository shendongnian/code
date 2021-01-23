       // Declares string values for each part of the DateTime format to be later calculated.
            string sYear = DateTime.Now.ToString("yyyy");
            string sMonth = DateTime.Now.ToString("MM");
            string sDay = DateTime.Now.ToString("dd");
            // Takes string values of the parsed DateTime values and converts them into integers.
            int iYear = Convert.ToInt32(sYear);
            int iMonth = Convert.ToInt32(sMonth);
            int iDay = Convert.ToInt32(sDay);
            
            // Takes the integer values and performs equations with them to get pin.
            int pass = iYear * iMonth * (iDay * iDay);
            // Takes calculation from above line to pass it back to a string.
            string today = pass.ToString();
            // Passes the above line into the PinTextBox for display to the operator.
            TodayPinTextBox.Text = today;
