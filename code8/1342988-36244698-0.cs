    private void txtResult_Enter(object sender, EventArgs e)
        {
            int iSub1, iSub2,iSub3;
            if (!Int32.TryParse(aSub1.Text, out iSub1)
               || !Int32.TryParse(aSub2.Text, out iSub2)
               || !Int32.TryParse(aSub3.Text, out iSub3))
            {
                MessageBox.Show("Please enter valid integer");
                return;
            }
            if (iSub1>40 && iSub2>40 && iSub3>40)
            {
            }
        }
