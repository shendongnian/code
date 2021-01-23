        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var item = GetItemAt(indexPath);
            var cell = GetOrCreateCellFor(tableView, indexPath, item);
            var bindable = cell as IMvxDataConsumer;
            if (bindable != null)
                bindable.DataContext = item;
            return cell;
        }
