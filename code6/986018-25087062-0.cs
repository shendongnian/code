    private void button1_Click(object sender, EventArgs e)
    {
        //mock up some dynamically passed in parameters
        var testParams = new List<object>();
        testParams.Add("1");
        testParams.Add("Hello");
    
        //the args I'm building up to pass to my dynamically chosen method
        var myArgs = new List<object>();
                
        //reflection to get the method
        var methodInfo = this.GetType().GetMethod("test");
        var methodParams = methodInfo.GetParameters();
    
        //loop through teh dynamic parameters, change them to the type of the method parameters, add them to myArgs
        var i = 0;
        foreach (var prop in methodParams)
        {
            myArgs.Add(Convert.ChangeType(testParams[i], prop.ParameterType));
            i++;
        }
    
        //invoke method
        var ans = methodInfo.Invoke(this, myArgs.ToArray());
    
        //display answer
        MessageBox.Show((string)ans);
    }
    
    public string test(int i, string s)
    {
        return s + i.ToString();
    }
