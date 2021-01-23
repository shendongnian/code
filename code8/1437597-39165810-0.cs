    var name = txtName.Text;
    Byte outAge;
    bool result= Byte.TryParse(txtAge.Text, NumberStyles.Integer,null as IFormatProvider, out outAge);
    if (!result)
    {
    //show your message box;
    }
    else
    {
    var age=outAge;
    }
