                if (TxtSSN.ReadOnly == true)
                {
                    string ssn1 = reader[4].ToString().Substring(0, 3);
                    string ssn2 = reader[4].ToString().Substring(3, 2);
                    string ssn3 = reader[4].ToString().Substring(5, 4);
                    TxtSSN.Text = ssn1 + '-' + ssn2 + '-' + ssn3;
                }
                else
                {
                    TxtSSN.Text = reader[4].ToString();    //unformatted
                }
