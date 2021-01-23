    private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length <= 2)
            {
                displayLabel5.Text = "0";
            }
            else
            {
                if (uFCheckBox.Checked == true)
                {
                    nFCheckBox.Checked = false;
                    pFCheckBox.Checked = false;
                    decimal x = 0;
                    if (Decimal.TryParse(textBox1.Text, out x))
                    {
                        var y = 1000000;
                        var answer = x * y;
                        displayLabel2.Text = (x.ToString().Replace(".", "").TrimStart(new Char[] { '0' }) + "00").Substring(0, 2);
                        var str = answer.ToString();
                        //decimal n = str.Split('.')[0].Substring(2, str.Length - 2).Count( s => s == '0');
                        //decimal n = str.Split('.')[0].Substring(2, str.Length - 2).Where(d => d == '0').Count(s => s == '0');
                        //decimal n = str.Split('.')[0].Where(d => d == '0').Count(s => s == '0');
                        decimal n = str.Split('.')[0].Substring(2).Where(d => d == '0').Count(s => s == '0');
                        displayLabel5.Text = n.ToString();
                    }
                    else
                    {
                        displayLabel2.Text = "error";
                    }
                }
            }
        }
