            //Set attribute for underlineing information links
            var underlineAttr = new UIStringAttributes { UnderlineStyle = NSUnderlineStyle.Single, ForegroundColor = UIColor.White };
            //Privacy Button Link
            var PrivacyPolicy = new UIButton(new CGRect(10, s.MxHt - 40, (s.MxWd - 20) / 3, 30));
            PrivacyPolicy.BackgroundColor = UIColor.FromRGB(0, 92, 191);
            PrivacyPolicy.Font = UIFont.FromName("Roboto", 14f);            
            PrivacyPolicy.SetAttributedTitle(new NSAttributedString("Privacy Policy", underlineAttr), UIControlState.Normal);
            PrivacyPolicy.TouchUpInside += HandleBtnOpenPrivacyTouchUpInside;            
            if (iPad == false) { PrivacyPolicy.Font = UIFont.SystemFontOfSize(12); }            
            View.AddSubview(PrivacyPolicy);
