	using System;
	using System.Drawing;
	using System.Windows.Forms;
	namespace RichTextBoxFindWithReverse
	{
		class ClsRichTextBox : RichTextBox
		{
			ClsFindMetadata objFindMetadata = null;
			ClsRichTextBoxSelectionArgs objRichTextBoxSelectionArgs = null;
			public ClsRichTextBox() : base()
			{
				SelectionChanged += ClsRichTextBox_SelectionChanged;
				objFindMetadata = new ClsFindMetadata();
				objRichTextBoxSelectionArgs = new ClsRichTextBoxSelectionArgs();
			}
			/// <summary>
			/// Clear the find data and highlighting (yellow background) if the user clicks on the text in the control
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void ClsRichTextBox_SelectionChanged(object sender, EventArgs e)
			{
				ClearLastFind();
				objRichTextBoxSelectionArgs.Set(SelectionStart);
				OnSelectionDataIsInteresting(objRichTextBoxSelectionArgs);
			}
			/// <summary>
			/// If last find data is available (findIndex, findLength), clear the highlighting 
			/// </summary>
			public void ClearLastFind()
			{
				SelectionChanged -= ClsRichTextBox_SelectionChanged;
				ControlExtensions.Suspend(this);
				int saveSelectionStart = SelectionStart;
				if (objFindMetadata.findStart != -1)
				{
					objFindMetadata.ClearFind();
				}
				if (objFindMetadata.highLightStart != -1)
				{
					Select(objFindMetadata.highLightStart, objFindMetadata.highLightLength);
					objFindMetadata.ClearHighLight();
					SelectionBackColor = Color.White;
					SelectionLength = 0;
				}
				SelectionStart = saveSelectionStart;
				ControlExtensions.Resume(this);
				SelectionChanged += ClsRichTextBox_SelectionChanged;
			}
			// -----------------------------------------------------------------------
			// -----------------------------------------------------------------------
			// -----------------------------------------------------------------------
			/// <summary>
			/// If searchText is found, returns true. Otherwise, returns false
			/// </summary>
			/// <param name="searchText"></param>
			/// <param name="isReverse"></param>
			/// <param name="isMatchCase"></param>
			/// <param name="isWholeWord"></param>
			/// <returns></returns>
			public bool FindTextCustom(string searchText, bool isReverse, bool isMatchCase, bool isWholeWord)
			{
				int previousSaveFindIndex = objFindMetadata.findStart;
				int previousSaveFindLength = objFindMetadata.findLength;
				int localForwardOffset = 1;
				int saveSelectionStart = SelectionStart;
				int saveSelectionLength = SelectionLength;
				int indexToplineCharOne = GetCharIndexFromPosition(new Point(0, 0));
				bool found = false;
				SelectionChanged -= ClsRichTextBox_SelectionChanged;
				ControlExtensions.Suspend(this);
				SelectionStart = saveSelectionStart;
				if (saveSelectionStart == 0 && objFindMetadata.findStart == -1)
				{
					localForwardOffset = 0;
				}
				if (!isReverse && !isMatchCase && !isWholeWord)
				{
					objFindMetadata.findStart = Find(searchText, Math.Min(SelectionStart + localForwardOffset, TextLength), Text.Length, RichTextBoxFinds.None);
				}
				else if (!isReverse && !isMatchCase && isWholeWord)
				{
					objFindMetadata.findStart = Find(searchText, Math.Min(SelectionStart + localForwardOffset, TextLength), Text.Length, RichTextBoxFinds.WholeWord);
				}
				else if (!isReverse && isMatchCase && !isWholeWord)
				{
					objFindMetadata.findStart = Find(searchText, Math.Min(SelectionStart + localForwardOffset, TextLength), Text.Length, RichTextBoxFinds.MatchCase);
				}
				else if (!isReverse && isMatchCase && isWholeWord)
				{
					objFindMetadata.findStart = Find(searchText, Math.Min(SelectionStart + localForwardOffset, TextLength), Text.Length, RichTextBoxFinds.MatchCase | RichTextBoxFinds.WholeWord);
				}
				else if (isReverse && !isMatchCase && !isWholeWord)
				{
					objFindMetadata.findStart = Find(searchText, 0, SelectionStart, RichTextBoxFinds.Reverse);
				}
				else if (isReverse && !isMatchCase && isWholeWord)
				{
					objFindMetadata.findStart = Find(searchText, 0, SelectionStart, RichTextBoxFinds.WholeWord | RichTextBoxFinds.Reverse);
				}
				else if (isReverse && isMatchCase && !isWholeWord)
				{
					objFindMetadata.findStart = Find(searchText, 0, SelectionStart, RichTextBoxFinds.MatchCase | RichTextBoxFinds.Reverse);
				}
				else // (isReverse && isMatchCase && isWholeWord)
				{
					objFindMetadata.findStart = Find(searchText, 0, SelectionStart, RichTextBoxFinds.MatchCase | RichTextBoxFinds.WholeWord | RichTextBoxFinds.Reverse);
				}
				found = false;
				if (objFindMetadata.findStart >= 0)
				{
					if (!isReverse)
					{
						if (saveSelectionStart <= objFindMetadata.findStart)
						{
							found = true;
						}
					}
					else
					{
						if (SelectionStart < saveSelectionStart)
						{
							found = true;
						}
					}
				}
				if (found)
				{
					// ClearLastFind isn't applicable because it clears find metadata. Just clear the highlight
					if (previousSaveFindIndex != -1)
					{
						Select(objFindMetadata.highLightStart, objFindMetadata.highLightLength);
						objFindMetadata.ClearHighLight();
						SelectionBackColor = Color.White;
					}
					objFindMetadata.highLightStart = objFindMetadata.findStart;
					objFindMetadata.highLightLength = objFindMetadata.findLength = searchText.Length;
					Select(objFindMetadata.findStart, objFindMetadata.findLength);
					SelectionBackColor = Color.Yellow;
					SelectionLength = 0;
				}
				else
				{
					objFindMetadata.ClearFind();
					SelectionLength = 0;
					SelectionStart = saveSelectionStart;
				}
				ControlExtensions.Resume(this);
				objRichTextBoxSelectionArgs.Set(SelectionStart);
				OnSelectionDataIsInteresting(objRichTextBoxSelectionArgs);
				SelectionChanged += ClsRichTextBox_SelectionChanged;
				Focus();
				return found;
			}
			/// <summary>
			/// Method used to invoke the event that is used to report RTB SelectionStart to interested parties
			/// https://docs.microsoft.com/en-us/dotnet/api/system.eventhandler-1?view=netframework-4.7.2
			/// </summary>
			/// <param name="e"></param>
			protected virtual void OnSelectionDataIsInteresting(ClsRichTextBoxSelectionArgs e)
			{
				SelectionDataIsInteresting?.Invoke(this, e);
			}
			/// <summary>
			/// Event used to report RTB SelectionStart to interested parties
			/// </summary>
			public event EventHandler<ClsRichTextBoxSelectionArgs> SelectionDataIsInteresting;
			/// <summary>
			/// Class used to record state of find results and find highlighting
			/// </summary>
			private class ClsFindMetadata
			{
				internal int findStart = -1;
				internal int findLength = -1;
				internal int highLightStart = -1;
				internal int highLightLength = -1;
				internal void ClearFind()
				{
					findStart = -1;
					findLength = -1;
				}
				internal void ClearHighLight()
				{
					highLightStart = -1;
					highLightLength = -1;
				}
			}
		}
		/// <summary>
		/// Class used to report RTB SelectionStart to interested parties
		/// </summary>
		public class ClsRichTextBoxSelectionArgs : EventArgs
		{
			internal void Set(int selectionStart)
			{
				SelectionStart = selectionStart;
			}
			public int SelectionStart { get; set; }
		}
	}
