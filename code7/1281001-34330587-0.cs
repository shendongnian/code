    public class MyClass
    {
       public static bool continueOperation = true;
    
    internal void ValidateEmailAddress(ServiceClient sc, Entity target, string emailaddress, string IsValid, string remark, string message)
    {
        continueOperation = true;
        AppDomain currentDomain = AppDomain.CurrentDomain;
        currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);
        System.Timers.Timer aTimer = new System.Timers.Timer();
        aTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
        aTimer.Interval = 5000; // 5 second
        aTimer.Enabled = true;
        if (emailaddress != string.Empty || (ContainData(target, IsValid) && target[IsValid] == null))
        {
            string[] returnstr = (string[])sc.VerifyEmail(emailaddress);
            string resultValue = string.Empty;
            OptionSetValue isvalid = null;
            foreach (var item in returnstr)
            {
                if(!continueOperation)
                   break;
                {
                  if (!item.ToLower().ToString().Equals("success"))
                  {
                    if (item.ToLower().ToString().Equals("serveriscatchall"))
                    {
                        isvalid = new OptionSetValue(1);
                    }
                    else
                        isvalid = new OptionSetValue(0);
                    resultValue = item;
                    break;
                  }
                  else
                  {
                    isvalid = new OptionSetValue(1);
                  }
            }
            if(!continueOperation)
                isvalid = new OptionSetValue(3);
            if (isvalid != null)
            {
                target[IsValid] = isvalid;
            }
            if (resultValue.Length > 0)
            {
                string returnValue = GetSysConfig(resultValue);
                if (returnValue != null)
                {
                    target[remark] = returnValue;
                }
                else
                    target[remark] = GetSysConfig("Others") + "(Error : " + resultValue + ")";
            }
            else
            {
                target[remark] = null;
            }
        }
     // I need to capture timer elapse event here and then i will update email address as Not able to verify
     // How can i do this?   
    }
       static void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
       {
           continueOperation = false;
           Console.WriteLine("0.5 seconds already over");
       } 
    }
