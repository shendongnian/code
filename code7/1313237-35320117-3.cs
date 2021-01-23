    public class TestEventListaener : EventListener
    {
        // The test collection started/finished to run. 
        void RunStarted(string name, int testCount);
        void RunFinished(TestResult result );
		void RunFinished(Exception exception );
        
        void TestStarted(TestName testName)
        {
            // create folder with the test name     
        }
        void TestFinished(TestResult result)
        {
            // if test succeeded insert data to the folder otherwise delete it
        }
        // more `EventListener` methods
    }
