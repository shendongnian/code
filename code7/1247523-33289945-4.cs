     private void onChanged(object sender, EventArgs e)
     {
         int t1;
         int t2;
         int t3;
         Int32.TryParse(Txt1.Text, out t1);
         Int32.TryParse(Txt2.Text, out t2);
         Int32.TryParse(Txt3.Text, out t3);
         txtTotal.Text = (t1+t2+t3).ToString();
     }  
