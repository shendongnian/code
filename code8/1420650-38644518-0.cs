    if(!string.IsNullOrWhiteSpace(OLR_FF.Text.ToString()))
    {
        //if the foreach loop is in groupbox1
        if(groupbox1.Equals(OLR_FF.Parent))
        {                           
            //do something
        }
        // or if its in groupbox2 
        else if(groupbox2.Equals(OLF_FF.Parent))
        {
            //do something different.
        }
        //sw.WriteLine("Name"+ Name++ + "=" + OLR_FF.Text.ToString());
    }
