    for (int t = 0; t < 8; t++)
     {
       rndString =""; //Change 1
       while (!Regex.IsMatch((c = Convert.ToChar(adomRng.Next(48, 128))).ToString(), "[a-z0-9]")) ;
       rndString += c;
       listBox1.Items.Add(rndString);// change  2
     }
           
