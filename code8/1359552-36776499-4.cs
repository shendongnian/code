    [TestClass]
    public class ClaimExistsRuleUnitTest
    {        
    	[TestMethod]
    	public void Returns_IsBau_When_Claim_DoesNotExist()
    	{
    		var builderUnitOfWork = new UnitOfWorkMockBuilder(true);
    
    		var claimId = "666"; // The DEVIL!!!!!
    		var process = "MyAwesomeProcess";
    
    		// -----
    		// ARRANGE
    		// -----
    		var depUnitOfWork = builderUnitOfWork.CreateMock().Object;
    		var depProcess = depUnitOfWork.Processes.GetAll().Where(x => x.FriendlyName == process).First();
    		var depClaimMessage = new ClaimMessage();
    		var mockValidationResult = null as IValidationResult;
    
    		depClaimMessage.ClaimId = claimId;
    		depClaimMessage.StpClaimRequestProcessId = depProcess.Stp_Process_Code_Id;
    
    		// -----
    		// ACT
    		// -----
    		var rule = new ClaimExistsRule();
    		rule.UnitOfWork = depUnitOfWork;
    
    		mockValidationResult = rule.Validate(depClaimMessage);
    
    		// -----
    		// ASSERT
    		// -----
    		Assert.AreEqual(ClaimAction.IsBAU, mockValidationResult.Action);
    	}
    
    	#endregion
    }
