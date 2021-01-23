	[TestFixture]
	public class myfixture {
		[Test]
		public void MyAssertCheckTest(){ // this test will fail if all other test fails
			var mytests = new Action[]{Test1,Test2};
			int failcount = mytests.Length;
			foreach(var test in mytests){
				try{
					test();
				}catch{
					if(--failcount==-1){
						Assert.Fail("too many fails");
					}
				}
			}
		}
		[Test]
		[Explicit] //mark it explicit - we want to check it only if MyAssertCheckTest fails
		public void Test1(){
			Assert.True(false);
		}
		
		[Test]
		[Explicit]
		public void Test2(){
			Assert.True(true);
		}	
    }
