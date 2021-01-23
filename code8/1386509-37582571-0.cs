		void richTextBox_Loaded(object sender, RoutedEventArgs e)
		{
			TextRange range = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
			range.Text = "Here is one line with some text" + Environment.NewLine;
			range.Text += "Here is another line Sikertelen csatlakozás with some text" + Environment.NewLine;
			range.Text += "Here is another line with some text" + Environment.NewLine;
			range.Text += "Here is another line Sikertelen csatlakozás with some text" + Environment.NewLine;
			range.Text += "Here is one line with some text" + Environment.NewLine;
			range.Text += "Here is another line Sikertelen csatlakozás with some text" + Environment.NewLine;
			range.Text += "Here is another line with some text" + Environment.NewLine;
			range.Text += "Here is another line Sikertelen csatlakozás with some text" + Environment.NewLine;
			String strSearch = "Sikertelen csatlakozás";
			int start = range.Text.IndexOf(strSearch);
			TextPointer tp = null;
			
			if (start > -1)
			{
				tp = range.Start.GetPositionAtOffset(start);
			}
			while (tp != null)
			{
				TextPointer tpLine = tp.GetLineStartPosition(0);
				TextPointer tpLineEnd = tp.GetLineStartPosition(1);
				TextPointer lineEnd = (tpLineEnd !=null ? tpLineEnd : tp.DocumentEnd).GetInsertionPosition(LogicalDirection.Backward);
				TextRange redText = new TextRange(tpLine, lineEnd);
				redText.ApplyPropertyValue(TextElement.ForegroundProperty, Brushes.Red);
				tp = tpLineEnd;
				if (tp != null)
				{
					start = range.Text.IndexOf(strSearch, start + 1);
					if (start > -1)
					{
						tp = range.Start.GetPositionAtOffset(start);
					}
				}
			}
		}
