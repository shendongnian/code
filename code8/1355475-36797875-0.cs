    public class SAFutureAdDetailElement : Element, IElementSizing
    {
        public SAFutureAdDetailElement(Ad ad, NSAction tapped) : base("FutureAdDetail")
        {
            this.ad = ad;
            Tapped += tapped;
        }
        public SAFutureAdDetailElement(Ad ad) : base("FutureAdDetail")
        {
            this.ad = ad;
        }
        private static NSString cellKey = new NSString("SAFutureAdDetailElement");
        protected override NSString CellKey
        {
            get
            {
                return cellKey;
            }
        }
        public override UITableViewCell GetCell(UITableView tv)
        {
			var cell = tv.DequeueReusableCell (cellKey);
			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellKey);
				cell.IndentationLevel = 0;
				var x = 24;
				var contentWidth = tv.Bounds.Width - 30 - x;
				var issueAndSizeLabel = new UILabel (new RectangleF (x, 5, contentWidth / 2, cellHeight / 2 - 5).RoundFloats ()) {
					TextColor = UIColor.Black,
					Font = UIFont.BoldSystemFontOfSize (15),
					BackgroundColor = UIColor.Clear,
					ShadowColor = UIColor.Clear,
					TextAlignment = UITextAlignment.Left,
					ClipsToBounds = true,
					Text = string.Format ("{0} - {1}", ad.IssueCode, ad.AdvertSize)
				};
				var mailDateLabel = new UILabel (new RectangleF (issueAndSizeLabel.Frame.Right, 5, contentWidth / 4, cellHeight / 2 - 5).RoundFloats ()) {
					TextColor = UIColor.Black,
					Font = UIFont.BoldSystemFontOfSize (15),
					BackgroundColor = UIColor.Clear,
					ShadowColor = UIColor.Clear,
					TextAlignment = UITextAlignment.Left,
					ClipsToBounds = true,
					Text = string.Format ("Mail: {0}", ad.MailDate.ToShortDateString ())
				};
				var orderDateLabel = new UILabel (new RectangleF (x, cellHeight / 2 + 5, contentWidth / 3, cellHeight / 2 - 10).RoundFloats ()) {
					TextColor = UIColor.Gray,
					Font = UIFont.SystemFontOfSize (13),
					BackgroundColor = UIColor.Clear,
					ShadowColor = UIColor.Clear,
					TextAlignment = UITextAlignment.Left,
					ClipsToBounds = true,
					Text = string.Format ("Order: {0}", ad.OrderDate.ToShortDateString ())
				};
				
				var totalLabel = new UILabel (new RectangleF (mailDateLabel.Frame.Right, 5, contentWidth / 4, cellHeight / 2 - 5).RoundFloats ()) {
					TextColor = UIColor.Black,
					Font = UIFont.BoldSystemFontOfSize (15),
					BackgroundColor = UIColor.Clear,
					ShadowColor = UIColor.Clear,
					TextAlignment = UITextAlignment.Right,
					ClipsToBounds = true,
					Text = string.Format ("Total: {0}", ad.Total.ToCurrency ())
				};
				var miscLabel = new UILabel (new RectangleF (totalLabel.Frame.Left, cellHeight / 2 + 5, contentWidth / 4, cellHeight / 2 - 10).RoundFloats ()) {
					TextColor = UIColor.Gray,
					Font = UIFont.SystemFontOfSize (13),
					BackgroundColor = UIColor.Clear,
					ShadowColor = UIColor.Clear,
					TextAlignment = UITextAlignment.Right,
					ClipsToBounds = true,
					Text = string.Format ("Misc: {0}", ad.Misc.ToCurrency ())
				};
				var indicator = new UIImageView (new RectangleF (5, 0, AppearanceManager.MonthlyIndicator.Size.Width, cellHeight));
				indicator.ContentMode = UIViewContentMode.ScaleAspectFit;
				if (ad.IsCCOPackage) {
					indicator.Image = AppearanceManager.CcoIndicator;
				} else if (ad.IsMonthlyBilling) {
					indicator.Image = AppearanceManager.MonthlyIndicator;
				}
					
				cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
				cell.ContentView.AddSubviews (indicator, issueAndSizeLabel, mailDateLabel, orderDateLabel, miscLabel, totalLabel);
			}
			((UILabel)cell.ContentView.Subviews[1]).Text = string.Format("{0} - {1}", ad.IssueCode, ad.AdvertSize);
			((UILabel)cell.ContentView.Subviews[2]).Text = string.Format("Mail: {0}", ad.MailDate.ToShortDateString());
			((UILabel)cell.ContentView.Subviews[3]).Text = string.Format("Order: {0}", ad.OrderDate.ToShortDateString());
			((UILabel)cell.ContentView.Subviews[4]).Text = string.Format("Misc: {0}", ad.Misc.ToCurrency());
			((UILabel)cell.ContentView.Subviews[5]).Text = string.Format("Total: {0}", ad.Total.ToCurrency());
			if (ad.IsCCOPackage) {
				((UIImageView)cell.ContentView.Subviews [0]).Image = AppearanceManager.CcoIndicator;
			} else if (ad.IsMonthlyBilling) {
				((UIImageView)cell.ContentView.Subviews [0]).Image = AppearanceManager.MonthlyIndicator;
			} else {
				((UIImageView)cell.ContentView.Subviews [0]).Image = null;
			}
            return cell;
        }
        public override void Selected(DialogViewController dvc, UITableView tableView, NSIndexPath path)
        {
            if (Tapped != null)
                Tapped ();
            tableView.DeselectRow (path, true);
        }
        public float GetHeight(UITableView tableView, NSIndexPath indexPath)
        {
			return cellHeight;
        }
		private Ad ad;
		public event NSAction Tapped;
		private int cellHeight = 60;
    }
