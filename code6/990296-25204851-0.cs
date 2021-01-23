	public class TestRunner{
		public void RunTest(Action FuncToRun){
			FuncToRun();        
		}
	}
	
	public class Tests{
		public void Test(){
			...Run test methods...
		}
		TestRunner.RunTest(() => Test());
	}	
