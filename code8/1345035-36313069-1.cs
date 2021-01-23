    int a;
    
    if(int.TryParse(adm_pass.Substring(adm_pass.IndexOf("-") + 1,1),out a))
    {
        //Code if next character is an int
    }
    else
    {
        adm_pass = adm_pass.Replace("-","_");
    }
