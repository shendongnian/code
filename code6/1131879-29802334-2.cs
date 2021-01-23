    class testclass
    {
         string teststring1 = ""; //visible in both methods
         private void testmethod1()
         {
             string teststring2 = ""; //only visible in this method
             teststring1 = "it works!";
         }
         private void testmethod2()
         {
             teststring2 = "this won't compile"; //teststring2 is not visible here
             teststring1 = "it works, too";
             //but what you are doing is:
             string teststring2 = ""; //new variable (not related to teststring2 from above)
         }
    }
