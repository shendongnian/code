    //Declaring and initializing obSMS. var keyword uses implicit typing.
    var obSMS = new SMSEmpresarial.clsSMS();
    //Declaring this as dynamic, because I have no clue what the eventual type will be.
    dynamic vMessages = new object();
    obSMS.GetEstado(ref vMessages);
    
    foreach(var message in vMessages)
    {
        //this replaces Me
        //+ is used to concatenate instead of &
        //[] is the index accessor in C#
        //ToString() is called instead of CStr()
        this.ListBox1.Items.Add("Cod:" + vMessages[0].ToString() + ":Tel:" + vMessages[1].ToString() + ":Est:" + vMessages[2].ToString() + ":Obs:" + vMessages[3].ToString());
    }
    
