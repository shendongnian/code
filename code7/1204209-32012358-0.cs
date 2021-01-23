    using System.Text;
    using System.Activities.Hosting;
    using System.Activities;
    using System.Diagnostics;
    using System.Threading.Tasks;
    using System.Threading;
    
    namespace Sample.Activities
    {
        /// <summary>
        /// Class Non-Blocking Native Activity
        /// </summary>
        public abstract class NonblockingNativeActivity : NativeActivity
        {
            private Variable<NoPersistHandle> NoPersistHandle { get; set; }
            private Variable<Bookmark> Bookmark { get; set; }
    
            private Task m_Task;
            private Bookmark m_Bookmark;
            private BookmarkResumptionHelper m_BookmarkResumptionHelper;
    
            /// <summary>
            /// Allows the activity to induce idle. 
            /// </summary>
            protected override bool CanInduceIdle
            {
                get
                {
                    return true;
                }
            }
    
            /// <summary>
            /// Prepars for Execution
            /// </summary>
            /// <param name="context"></param>
            protected virtual void PrepareToExecute(
                NativeActivityContext context)
            {
            }
    
            /// <summary>
            /// Executes a Non-blocking Activity
            /// </summary>
            protected abstract void ExecuteNonblocking();
    
            /// <summary>
            /// After Execution Completes
            /// </summary>
            /// <param name="context"></param>
            protected virtual void AfterExecute(
                NativeActivityContext context)
            {
            }
    
            /// <summary>
            /// Executes the Activity
            /// </summary>
            /// <param name="context"></param>
            protected override void Execute(NativeActivityContext context)
            {
    
                //
                //  We must enter a NoPersist zone because it looks like we're idle while our
                //  Task is executing but, we aren't really
                //
                NoPersistHandle noPersistHandle = NoPersistHandle.Get(context);
                noPersistHandle.Enter(context);
    
                //
                //  Set a bookmark that we will resume when our Task is done
                //
                m_Bookmark = context.CreateBookmark(BookmarkResumptionCallback);
                this.Bookmark.Set(context, m_Bookmark);
                m_BookmarkResumptionHelper = context.GetExtension<BookmarkResumptionHelper>();
    
                //
                //  Prepare to execute
                //
                PrepareToExecute(context);
    
                //
                //  Start a Task to do the actual execution of our activity
                //
                CancellationTokenSource tokenSource = new CancellationTokenSource();
                m_Task = Task.Factory.StartNew(ExecuteNonblocking, tokenSource.Token);
                m_Task.ContinueWith(TaskCompletionCallback);
            }
    
            private void TaskCompletionCallback(Task task)
            {
                if (!task.IsCompleted)
                {
                    task.Wait();
                }
    
                //
                //  Resume the bookmark
                //
                m_BookmarkResumptionHelper.ResumeBookmark(m_Bookmark, null);
            }
    
    
            private void BookmarkResumptionCallback(NativeActivityContext context, Bookmark bookmark, object value)
            {
                var noPersistHandle = NoPersistHandle.Get(context);
    
                if (m_Task.IsFaulted)
                {
                    //
                    //  The task had a problem
                    //
                    Console.WriteLine("Exception from ExecuteNonBlocking task:");
                    Exception ex = m_Task.Exception;
                    while (ex != null)
                    {
                        Console.WriteLine(ex.Message);
                        ex = ex.InnerException;
                    }
    
                    //
                    // If there was an exception exit the no persist handle and rethrow.
                    //
                    if (m_Task.Exception != null)
                    {
                        noPersistHandle.Exit(context);
                        throw m_Task.Exception;
                    }
                }
    
                AfterExecute(context);
    
                noPersistHandle.Exit(context);
            }
    
            //
            //  TODO: How do we want to handle cancelations?  We can pass a CancellationToekn to the task
            //  so that we cancel the task but, maybe we can do better than that?
            //
            /// <summary>
            /// Abort Activity
            /// </summary>
            /// <param name="context"></param>
            protected override void Abort(NativeActivityAbortContext context)
            {
                base.Abort(context);
            }
    
            /// <summary>
            /// Cancels the Activity
            /// </summary>
            /// <param name="context"></param>
            protected override void Cancel(NativeActivityContext context)
            {
                base.Cancel(context);
            }
    
            /// <summary>
            /// Registers Activity Metadata
            /// </summary>
            /// <param name="metadata"></param>
            protected override void CacheMetadata(NativeActivityMetadata metadata)
            {
                base.CacheMetadata(metadata);
                this.NoPersistHandle = new Variable<NoPersistHandle>();
                this.Bookmark = new Variable<Bookmark>();
                metadata.AddImplementationVariable(this.NoPersistHandle);
                metadata.AddImplementationVariable(this.Bookmark);
                metadata.RequireExtension<BookmarkResumptionHelper>();
                metadata.AddDefaultExtensionProvider<BookmarkResumptionHelper>(() => new BookmarkResumptionHelper());
            }
        }
    }
