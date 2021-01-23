    [TestMethod]
    public void Check_ProcessDormantApplications()
    {
        ////arrange
        var applicationId = new List<long>()
        {
            //put here some ids
        };
        
        DormantServiceAdapter.Stub(x => x.GetDormantApplications()).Return(applicationId);
        var target = new DormantApplicationsBusinessLogic(DormantServiceAdapter, logger);
        ////act        
        target.ProcessDormantApplications();
        ////assert
        foreach (var id in applicationId)
        {
            DormantServiceAdapter.AssertWasCalled(x => x.UpdateDormantApplications(id));
        }
    }
