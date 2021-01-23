    public static class TestHelper{
       public static Results ClickMe (this Button button){
         button.Click();
         var results = GetResults(button);
         return results;
       }
    }
