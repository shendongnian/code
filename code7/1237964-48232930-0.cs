    Console.WriteLine("You are speaking {0}", 
    System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName);
    res_man = new ResourceManager("MyApp.lang_"+ System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName, Assembly.GetExecutingAssembly());
                      
    lblError.Text = res_man.GetString("lbl_error");
