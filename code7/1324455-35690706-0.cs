    public string temp()
        {
            string temp = "123";
            return temp;  // things that i wanted to pass from this class 
        }
    }
    private void STARTbtn_Click(object sender, EventArgs e)
        {
            Gettemp _GetTemp = new Gettemp();
            string temp = _GetTemp.temp();
            MessageBox.Show(temp);
        }
