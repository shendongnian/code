    public class TestRunner{
        public void RunTest(Action funcAction){
            funcAction();        
        }
    }
    
    public class Tests{
        public void Test(){}
        TestRunner.RunTest(Test);
    }
