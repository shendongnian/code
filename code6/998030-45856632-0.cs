    public void ValidationUserInfo(string userName,string password)
    {
        //Do validations with password, after converting it to secureString and fetch it out?....
        
        //Just clear the memory!
        ClearSensiveString(password);
        //Do any others or return after validations.....
    }
    
    //Your memory clear way:
    
    static unsafe void ClearSensiveString(string sensiveValue,char coverChar='\0')
            {
                fixed(char* c = sensiveValue)
                {
                    for (int i = 0; i < sensiveValue.Length; i++)
                    {
                        c[i] = coverChar;
                    }
                }
            }
