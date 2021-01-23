    Console.WriteLine("Enter the plain text: ");
    string ptxt=Console.ReadLine();
    ptxt= ptxt.ToUpper();
    char[] ptxtarr = ptxt.ToCharArray();
    for(i=0; i<=ptxt.Length;i++)         
    {
        if(char.IsLetter(ptxtarr[i]))
        {
            nptxtarr.Add(ptxtarr[i]);
        } 
    }
