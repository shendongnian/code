    public void OnRunJavascript(object sender, JavascriptEventArgs e)
    {
        if (Control != null)
        {
            var jsr = new JavascriptResult();
            Control.EvaluateJavascript(string.Format("javascript: {0}", e.Script), jsr);
            // TODO await jsr.CompletionTask
            e.Result = jsr.Result;
         }
    }
    public class JavascriptResult : Java.Lang.Object, IValueCallback
    {
        public string Result;
        
        public Task CompletionTask {get { return jsCompletionSource.Task; } }
        private TaskCompletionSource<bool> jsCompletionSource = new TaskCompletionSource<bool>();
        public void OnReceiveValue(Java.Lang.Object result)
        {
            string json = ((Java.Lang.String)result).ToString();
            Result = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(json);
            Notify();
            jsCompletionSource.SetResult(true); // completes the Task
            // the await will finish
        }
    }
