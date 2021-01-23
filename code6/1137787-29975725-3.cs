        [assembly:ExportRenderer (typeof(LRMasterDetailPage), typeof(LRMDPRenderer))]
    namespace Manager.iOS
    {
    	public class LRMDPRenderer : ViewRenderer<LRMasterDetailPage,UIView>
    	{
    		
    		UILongPressGestureRecognizer longPressGestureRecognizer;
    		UIPinchGestureRecognizer pinchGestureRecognizer;
    		//UIPanGestureRecognizer panGestureRecognizer;
    		UISwipeGestureRecognizer swipeRightGestureRecognizer;
    		UISwipeGestureRecognizer swipeLeftGestureRecognizer;
    		UIRotationGestureRecognizer rotationGestureRecognizer;
    
    		protected override void OnElementChanged (ElementChangedEventArgs<LRMasterDetailPage> e)
    		{
    			base.OnElementChanged (e);
    
    			longPressGestureRecognizer = new UILongPressGestureRecognizer (() => Console.WriteLine ("Long Press"));
    			pinchGestureRecognizer = new UIPinchGestureRecognizer (() => Console.WriteLine ("Pinch"));
    			//panGestureRecognizer = new UIPanGestureRecognizer (() => Console.WriteLine ("Pan"));
    
    			swipeRightGestureRecognizer = new UISwipeGestureRecognizer ( () => UpdateRight()){Direction = UISwipeGestureRecognizerDirection.Right};
    			swipeLeftGestureRecognizer = new UISwipeGestureRecognizer ( () => UpdateLeft()){Direction = UISwipeGestureRecognizerDirection.Left};
    			rotationGestureRecognizer = new UIRotationGestureRecognizer (() => Console.WriteLine ("Rotation"));
    
    			if (e.NewElement == null) {
    				if (longPressGestureRecognizer != null) {
    					this.RemoveGestureRecognizer (longPressGestureRecognizer);
    				}
    				if (pinchGestureRecognizer != null) {
    					this.RemoveGestureRecognizer (pinchGestureRecognizer);
    				}
    
    				/*
    				if (panGestureRecognizer != null) {
    					this.RemoveGestureRecognizer (panGestureRecognizer);
    				}
    				*/
    
    				if (swipeRightGestureRecognizer != null) {
    					this.RemoveGestureRecognizer (swipeRightGestureRecognizer);
    				}
    				if (swipeLeftGestureRecognizer != null) {
    					this.RemoveGestureRecognizer (swipeLeftGestureRecognizer);
    				}
    
    				if (rotationGestureRecognizer != null) {
    					this.RemoveGestureRecognizer (rotationGestureRecognizer);
    				}
    			}
    
    			if (e.OldElement == null) {
    				this.AddGestureRecognizer (longPressGestureRecognizer);
    				this.AddGestureRecognizer (pinchGestureRecognizer);
    				//this.AddGestureRecognizer (panGestureRecognizer);
    				this.AddGestureRecognizer (swipeRightGestureRecognizer);
    				this.AddGestureRecognizer (swipeLeftGestureRecognizer);
    				this.AddGestureRecognizer (rotationGestureRecognizer);
    			}
    		}
    
    		private void UpdateLeft(){
    			MessagingCenter.Send ("Swiped to the left", "LeftSwipe");
    
    		}
    		private void UpdateRight(){
    			// same as for left, but flipped
    			MessagingCenter.Send ("Swiped to the Right", "RightSwipe");
    
    		}
    	}
    }
