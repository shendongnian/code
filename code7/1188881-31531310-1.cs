    using ProjectName;
    using ProjectName.iOS;
    using UIKit;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;
    [assembly:ExportRenderer(typeof(MyImageCell), typeof(MyImageCellRenderer))]
    namespace ProjectName.iOS
    {
        public class MyImageCellRenderer : ImageCellRenderer
        {
            public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
            {
                var c = base.GetCell(item, reusableCell, tv);
                var view = (MyImageCell)item;
                c.Accessory = view.ShowDisclosure
                    ? UITableViewCellAccessory.DisclosureIndicator
                    : UITableViewCellAccessory.None;
                return c;
            }
        }
    }
