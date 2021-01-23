    using System;
    using System.Threading.Tasks;
    using UIKit;
    
    namespace Seanfisher.Gists
    {
        public abstract class AsyncInitializationController : UIViewController
        {
            Task _viewDidLoadAsyncTask = Task.CompletedTask;
            public virtual Task ViewDidLoadAsync()
            {
                return _viewDidLoadAsyncTask;
            }
    
            public sealed override async void ViewDidLoad()
            {
                try
                {
                    base.ViewDidLoad();
                    _viewDidLoadAsyncTask = ViewDidLoadAsync();
                    await _viewDidLoadAsyncTask;
                }
                catch (Exception e)
                {
                    // Handle
                }
            }
    
            Task _viewWillAppearAsyncTask = Task.CompletedTask;
            public virtual Task ViewWillAppearAsync()
            {
                return _viewWillAppearAsyncTask;
            }
    
            public sealed override async void ViewWillAppear(bool animated)
            {
                try
                {
                    await _viewDidLoadAsyncTask;
                    base.ViewWillAppear(animated);
                    _viewWillAppearAsyncTask = ViewWillAppearAsync();
                    await _viewWillAppearAsyncTask;
                }
                catch (Exception e)
                {
                    // Handle
                }
            }
    
            Task _viewDidAppearAsyncTask = Task.CompletedTask;
            public virtual Task ViewDidAppearAsync()
            {
                return _viewDidAppearAsyncTask;
            }
            public sealed override async void ViewDidAppear(bool animated)
            {
                try
                {
                    await _viewDidLoadAsyncTask;
                    await _viewWillAppearAsyncTask;
    
                    base.ViewDidAppear(animated);
                    _viewDidAppearAsyncTask = ViewDidAppearAsync();
                    await _viewDidAppearAsyncTask;
                }
                catch (Exception e)
                {
                    // Handle
                }
            }
        }
    }
