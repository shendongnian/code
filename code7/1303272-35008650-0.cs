        catch (FaultException<ServiceException> e)
        {
            aufgabe.Error = Exceptionhandler.GetFaultExceptionMessages(e);
            aufgabe.IsProcessed = true;
            db.Edit(aufgabe);
            db.Dispose();
        }
 
    public static string GetFaultExceptionMessages(FaultException<ServiceException> e)
            {
                var msgs = "";
                foreach (var error in e.Detail.list)
                {
                    msgs += error.DetailMessage.ToString() + Environment.NewLine;
                }
    
                return msgs;
            }
