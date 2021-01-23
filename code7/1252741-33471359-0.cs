    //Put these two lines to where you want to check the connection
    Thread checkConnection = new Thread(checkConn);
    checkConnection.Start();
   
    //Then create a method like below
    public void checkConn()
    {
         //Call the check connection method here
         if(!miconexion(ip, user, pass))
         {
             //Handle failure here, please use Invoke if you want to control the UI thread.
         }
         //For best resource usage, join the thread after using it.
         Thead.Join();
    }
