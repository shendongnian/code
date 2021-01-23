     try
        {
           //Call services via the proxy
        }
        catch(FaultException fa)
        {
           switch(fa.Code.Name)
           {
             case “DBConnection”:
               MessageBox.Show(“Cannot connect to database!”);
               break;
             default:
               MessageBox.Show(“fa.message”);
               break;
            }
        }
