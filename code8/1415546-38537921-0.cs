		private void SelectionChangeHandler()
		{
			Outlook.Selection sel = activeExplorer.Selection;
			// First make sure it's a (single) mail item
			if (1 != sel.Count)
			{   // Ignore multi-select
				return;
			}
			// Indexed from 1, not 0. Stupid VB-ish thing...
			Outlook.MailItem mail = sel[1] as Outlook.MailItem;
			if (null != mail)
			{
				if (null != selectedMail)
				{   // Remove the old event handlers, if they were set, so there's no repeated events
					selectedMail.Forward -= MailItemResponseHandler;
					selectedMail.Reply -= MailItemResponseHandler;
					selectedMail.ReplyAll -= MailItemResponseHandler;
				}
				selectedMail = mail as Outlook.ItemEvents_10_Event;
				selectedMail.Forward += MailItemResponseHandler;
				selectedMail.Reply += MailItemResponseHandler;
				selectedMail.ReplyAll += MailItemResponseHandler;
				if (DecryptOnSelect)
				{   // We've got a live mail item selected. Process it
					ProcessMailitem(mail);
				}
			}
		}
