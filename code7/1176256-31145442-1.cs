    var str1 = "SAKVRLW";
    var str2 = "TCOEFO";
    
    var array2 = str2.ToCharArray();
    
    string.Join(string.Empty, 
                str1.ToCharArray()
                    .Select ((ch, index) => string.Format("{0}{1}", 
                                                           ch, 
                                                           index < array2.Length 
                                                           ? array2[index].ToString() 
                                                           : string.Empty  
                                                         )
                            )
               )
