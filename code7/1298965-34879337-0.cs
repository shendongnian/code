        public class TaskStringVisitor : CfxStringVisitor
        {
            private readonly TaskCompletionSource<string> taskCompletionSource;
            public TaskStringVisitor()
            {
                taskCompletionSource = new TaskCompletionSource<string>();
                this.Visit += TaskStringVisitor_Visit;
            }
            void TaskStringVisitor_Visit(object sender, Chromium.Event.CfxStringVisitorVisitEventArgs e)
            {
                try
                {
                    taskCompletionSource.SetResult(e.String);
                }
                catch (Exception ex)
                {
                    taskCompletionSource.SetException(ex);
                }
            }
            public Task<string> Task
            {
                get { return taskCompletionSource.Task; }
            }
        }
        public Task<string> GetSourceAsync()
        {
            TaskStringVisitor taskStringVisitor = new TaskStringVisitor();
            browser.MainFrame.GetSource(taskStringVisitor);
            return taskStringVisitor.Task;
        }
        async void loadHandler_OnLoadEnd(object sender, Chromium.Event.CfxOnLoadEndEventArgs e)
        {
            // Get HTML code
            string HTMLsource = await GetSourceAsync();
        }
