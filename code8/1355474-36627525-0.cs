    public override UITableViewCell GetCell(UITableView tv)
    {
        var cell = tv.DequeueReusableCell (cellKey);// as SAFutureAdCell;
        if (cell == null) {
            cell = new SAFutureAdCell(cellKey);
        }
        else
			{
				cell.Element = this;
			}
        cell.Update (ad);
        return cell;
    }
