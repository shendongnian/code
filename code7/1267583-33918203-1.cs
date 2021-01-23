         private void btnLog_Click(object sender, EventArgs e)
        {
            bindDataBeforeSending();
            BusinessLayer BUS = new BusinessLayer();      
            BUS.InsertLog(CustomerId,DateLogged,CustomerRef,AssignedEmployeeId,Description,ImpactId,RootCause,RootFix,StatusId,FixDate,TimeUsed,InternalRef);
        }
