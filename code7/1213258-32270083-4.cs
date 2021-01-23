       // this method is created to be called from a scenario outline
       // this contains the steps that one iteration of the outline should take.
       public virtual void Login(string login, string password, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Login", exampleTags);
			#line 13
			this.ScenarioSetup(scenarioInfo);
			#line 14
			testRunner.Given("I have navigated to the Login Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
			#line 15
			testRunner.When(string.Format("I enter a valid \'{0}\'", login), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
			#line 16
			testRunner.And(string.Format("I enter the correct \'{0}\'", password), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
			#line 17
			testRunner.And("I press the Login CTA", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
			#line 18
			testRunner.Then("I am logged into the Home Page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
			#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Login")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "LoginA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Login", "LoginA")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "passwordA")]
        public virtual void Login_LoginA()
        {
            // Calling the inner method Login
            this.Login("LoginA", "passwordA", ((string[])(null)));
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Login")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("VariantName", "LoginB")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Login", "LoginB")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("Parameter:Password", "passwordB")]
        public virtual void Login_LoginB()
        {
            this.Login("LoginB", "passwordB", ((string[])(null)));
        }
