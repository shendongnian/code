       /// <summary>
    /// Sets the selection checkmarks.
    /// </summary>
    public void BindImages()
    {
        List<Test> myTests= new List<Test>();
        foreach (var item in TestProject.Instance.TestHistory.Values)
        {
            myTests = item;
            foreach (Test test in myTests)
            {  
                if (TestProject.Instance.SelectedTest.ContainsKey(test.Order.Id))
                {
                    if (TestProject.Instance.SelectedTest[test.Order.Id] == test)                            
                    {
                        Dispatcher.CurrentDispatcher.DynamicInvoke(delegate()
                        {
                           test.ImageString=@"/TestProject;component/Resources/Testimage.gif"
                            
                        });                            
                    }       
                 }
             }
         }
    }
