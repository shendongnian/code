    bool noErrorMsg= true;
    noErrorMsg &= double.TryParse(opr1.Text, out Val1);
    noErrorMsg &= double.TryParse(opr2.Text, out Val2);
    if(!noErrorMsg)
    {
        //Error
    }
