            //output
            foreach (string s in matchedList)
            {
                string citationLine = s;
                string[] lineData = citationLine.Split(',');
                txtLicense2.Text = lineData[1];
                txtIssued2.Text = lineData[2];
                txtDue2.Text = lineData[3];
                txtStatus2.Text = lineData[4];
                txtAmount2.Text = lineData[5];
            }
