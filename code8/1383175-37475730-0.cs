    public class A : BaseClass
    {
        private String loginWindow;
        [FindsBy(How = How.Id, Using = "ALoginId"]
        public IWebElement Login {get; set;}
        [FindsBy(How = How.Id, Using = "APassword"]
        public IWebElement Password {get; set;}
        [FindsBy(How = How.Id, Using = "ALoginBtn"]
        public IWebElement LoginBtn {get; set;}
        [FindsBy(How = How.Id, Using = "BLoginId"]
         public IWebElement Loginb {get; set;}
        [FindsBy(How = How.Id, Using = "BPassword"]
        public IWebElement Passwordb {get; set;}
        [FindsBy(How = How.Id, Using = "BLoginBtn"]
        public IWebElement LoginBtnb {get; set;}
        public A(Srting loginwindow){
            	this.loginWindow; = loginwindow;
        }
        public void Login()
        {
         	if(loginwindow.equals("A")) {
            	Login.SendKeys("username");
        	    Password.SendKeys("password");
             	LoginBtn.Click();
	         }
             elseif(loginwindow.equals("B")){
         		Loginb.SendKeys("username");
             	Passwordb.SendKeys("password");
	            LoginBtnb.Click();
	         }
         	else{
	        	throws new Execption("Please provide correct login Window name")
	         }
         }
    }
