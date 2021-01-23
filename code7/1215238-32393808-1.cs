    [assembly: ExportRenderer(typeof(UIViewCell), typeof(UIViewCellRenderer))]
    namespace YourProjectNamespace.iOS.Renderers
    {
        public class UIViewCellRenderer: ViewCellRenderer
        {
            public override UITableViewCell GetCell(Cell item,UITableViewCell reusable, UITableView tv)
            {
                var cell = base.GetCell(item, reusable, tv);
    
                cell.BackgroundColor.ColorWithAlpha(0.5F);// set the opacity
                return cell;
            }
        }
    }
