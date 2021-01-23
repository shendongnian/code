    public class FirstTab : UIViewController
    {
        private  UIView content1;
        private  UIView content2;
        private  UIView content3;
        private  UIView containerView;
        private UIScrollView scrollView;
        CoreGraphics.CGSize contentViewSize;
        public FirstTab()
        {
            content1 = new UIView();
            content2 = new UIView();
            content3 = new UIView();
            containerView = new UIView();
            scrollView = new UIScrollView();
            contentViewSize = new CoreGraphics.CGSize(View.Frame.Width, View.Frame.Height + 800);
        }
        public override void ViewWillLayoutSubviews()
        {
            base.ViewWillLayoutSubviews();
            scrollView.ContentSize = contentViewSize;
        }
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            content1.BackgroundColor = UIColor.Red;
            content2.BackgroundColor = UIColor.Black;
            content3.BackgroundColor = UIColor.Brown;
          
            
            Constraint();
            
        }
        private void Constraint()
        {
            containerView.AddSubviews(content1, content2, content3);
            containerView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            containerView.AddConstraints(
                content1.Width().EqualTo(300),
                content1.Height().EqualTo(300),
                content1.AtTopOf(containerView).Plus(20),
                content1.WithSameCenterX(containerView),
                content2.Width().EqualTo(300),
                content2.Height().EqualTo(300),
                content2.Below(content1).Plus(20),
                content2.WithSameCenterX(containerView),
                content3.Width().EqualTo(300),
                content3.Height().EqualTo(300),
                content3.Below(content2).Plus(20),
                content3.WithSameCenterX(containerView)
                );
            scrollView.AddSubviews(containerView);
            scrollView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            scrollView.AddConstraints(
                containerView.WithSameHeight(scrollView).Plus(300),
                containerView.WithSameWidth(scrollView)
                );
            View.AddSubviews(scrollView);
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
            View.AddConstraints(
                scrollView.WithSameWidth(View),
                scrollView.WithSameHeight(View).Plus(400)
                );
         
        }
    }
