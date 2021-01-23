     case "hello":
     case "hello alexis":
     timenow = DateTime.Now;
     if (timenow.Hour >= 5 && timenow.Hour < 12)
     { Alexis.SpeakAsync("Goodmorning " + Settings.Default.User); }
     if (timenow.Hour >= 12 && timenow.Hour < 18)
     { Alexis.SpeakAsync("Good afternoon " + Settings.Default.User); }
     if (timenow.Hour >= 18 && timenow.Hour < 24)
     { Alexis.SpeakAsync("Good evening " + Settings.Default.User); }
     if (timenow.Hour < 5)
     { Alexis.SpeakAsync("Hello " + Settings.Default.User + ", it's getting late"); }
     break;
