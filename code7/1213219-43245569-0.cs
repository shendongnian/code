    int linecount=0;
    
    while ((line = streamReader.ReadLine()) != null)
    {
    linecount=linecount+1;
    }
    
    int number=0;
 
    while ((line = streamReader.ReadLine()) != null)
     {
    number=number+1;
        
        // what is yor work
    
    progressBar1.Value = i * progressBar1.Maximum / linecount;  //show process bar counts
    LabelTotal.Text = i.ToString() + " of " + linecount; //show number of count in lable
    int presentage = (i * 100) / linecount;
    LabelPresentage.Text = presentage.ToString() + " %"; //show precentage in lable
    Application.DoEvents(); //keep form active in every loop 
    }
