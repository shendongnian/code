    int divi=0;
    double sum=0;
            b1 = Convert.ToDouble(txtb1.Text);
    if(b1>0){ sum +=b1; divi++; }
    
            b2 = Convert.ToDouble(txtb2.Text);
    if(b2>0){ sum +=b2; divi++; }
    
            b3 = Convert.ToDouble(txtb3.Text);
    if(b3>0){ sum +=b3; divi++; }
    
            b4 = Convert.ToDouble(txtb4.Text);
    if(b4>0){ sum +=b4; divi++; }
    
    if(divi>0){ 
    result = sum / divi;
    }
            lblmedia.Text = result.ToString();
