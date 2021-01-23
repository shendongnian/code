    public sealed class WaitForResponse<TResult> : NativeActivity<TResult>
    {
        public string ResponseName { get; set; }
        protected override bool CanInduceIdle
        {
            get
            {
                return true;
            }
        }
        
        protected override void Execute(NativeActivityContext context)
        {
            context.CreateBookmark(this.ResponseName, new BookmarkCallback(this.ReceivedResponse));
            // Put code here...
        }
        void ReceivedResponse(NativeActivityContext context, Bookmark bookmark, object obj)
        {
            this.Result.Set(context, (TResult)obj);
        }
    
