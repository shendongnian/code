    abstract class MyBaseClass {
       protected abstract void DoSomething();
       public void DoSmtpStuff() {
           smtpClient.Connect();
           try {
               DoSomething();
           } catch (Exception ex) {
           }
           smtpClient.Disconnect();
       }
    }
