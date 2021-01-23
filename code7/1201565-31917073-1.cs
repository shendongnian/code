    private async void LogIntoWebSitesAsync()
    {
        // do some processing
        // if possible call other async functions
        await OtherFunctionAsync(); // use this if return value is Task
        TResult result = await YetAnotherAsync(); // use if return Task`<TResult`>
        // here you can use result
        
        // or if you want some parallel processing:
        var taskA = YetAnotherAsync();
        // while taskA is performing, do other things
        // after a while you need the result:
        TResult taskAResult = await taskA;
        // or even start several tasks:
        var taskX = functionXAsync(...);
        var taskY = functionYAsync(...);
        // do some more processing, and after a while you need the results:
        await Task.WhenAll( new Task[] {taskX, taskY});
        var Xresult = taskX.Result;
        var Yresult = taskY.Result;
        ProcessResults(XResult, YResult);
    }
