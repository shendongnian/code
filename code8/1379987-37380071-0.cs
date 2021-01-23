    using System;
    using System.Collections.Generic;
    using Microsoft.Office.Interop.Word;
    using System.IO;
    
    namespace MKML_Labels
    {
    	/// <summary>
    	/// Contains code to generate a Word document that can
    	/// be used to print &/or save the labels.
    	/// </summary>
    	public class Labels
    	{
    		#region Fields
    		public enum DestinationType : short
    		{
    			Invalid = 0,
    			Print,
    			Save,
    			Both,
    			Open
    		}
    
    		private DestinationType destType;
    		private string saveFilePath;
    		private const int BOLD = 1;
    		private const int UNBOLD = 0;
    
    		// L7160 is an Avery type, 21 labels per A4 sheet, 63.5x38.1 mm. See e.g. Amazon ASIN: B0082AWFP8
    		private const string LABEL_TYPE = "L7160";
    
    		// The following constants depend on the label type
    		private const int NUM_COLUMNS = 6;	// Number of columns on a sheet of labels, 3 labels and 3 separators
    		private const int NUM_ROWS = 7;	// Number of rows on a page (or sheet of labels)
    		private const int NAME_COLUMN_WIDTH = 130;
    		private const float NAME_FONT_SIZE = 14.0F;
    		private const float NUMBER_FONT_SIZE = 18.0F;
    		private const float TEXT_FONT_SIZE = 10.0F;
    		#endregion
    
    		#region Constructor
    		/// <summary>
    		/// Constructor
    		/// </summary>
    		/// <param name="dest">One of the DestinationType enum values</param>
    		/// <param name="path">Full path to the saved file (Word document containing the labels). May be empty if Save not chosen</param>
    		public Labels(DestinationType dest, string path)
    		{
    			destType = dest;
    			saveFilePath = path;
    		}
    		#endregion
    
    		#region Public Methods
    		/// <summary>
    		/// Print the labels
    		/// Copied and amended from http://stackoverflow.com/questions/18056117/miscrosoft-word-label-printing-utility-issue
    		/// </summary>
    		/// <param name="creditors">List of creditors</param>
    		/// <exception cref=">ApplicationException">Thrown when a Word error occurs</exception>
    		public void PrintLabels(List<Creditor> creditors)
    		{
    			Application wordApp;
    			wordApp = new Application();
    			Document wordDoc = null;
    			Object missing = System.Reflection.Missing.Value;
    
    			try
    			{
    				wordDoc = wordApp.Documents.Add();
    
    				// This adds one page full of a table with space for 21 labels. See below if more pages are necessary
    				// I don't know WHY we need 2 documents, but I can't get it to work with only one.
    				var newDoc = wordApp.MailingLabel.CreateNewDocument(LABEL_TYPE, "", Type.Missing, false, Type.Missing, Type.Missing, Type.Missing);
    				wordApp.Visible = false;
    
    				// Close the empty, original document
    				((_Document)wordDoc).Close(false, missing, missing);
    
    				var table = newDoc.Content.ConvertToTable().Tables[1];
    				int column = -1;
    				int row = 1;
    
    				// When row > n * 7, need to add new rows, because we have started a new page
    				foreach (Creditor c in creditors)
    				{
    					column += 2;
    					if (column > NUM_COLUMNS)
    					{
    						column = 1;
    						row++;
    						if (row > NUM_ROWS)
    						{
    							// After filling the first page, add a new row as required
    							table.Rows.Add();
    						}
    					}
    
    					// Create an inner table in the cell, with the name in bold and the number right-justified
    					var innertable = table.Cell(row, column).Range.ConvertToTable();
    					innertable.Columns[2].Cells[1].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
    					innertable.Columns[1].Cells[1].SetWidth(NAME_COLUMN_WIDTH, WdRulerStyle.wdAdjustFirstColumn);
    					innertable.Columns[1].Cells[1].Range.Text = c.Name;
    					innertable.Columns[1].Cells[1].Range.Font.Bold = BOLD;
    					innertable.Columns[1].Cells[1].Range.Font.Color = WdColor.wdColorBlack;
    					innertable.Columns[1].Cells[1].Range.Font.Size = NAME_FONT_SIZE;
    
    					innertable.Columns[2].Cells[1].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight;
    					innertable.Columns[2].Cells[1].Range.Text = c.LineNumber;
    					innertable.Columns[2].Cells[1].Range.Font.Bold = UNBOLD;
    					innertable.Columns[2].Cells[1].Range.Font.Color = WdColor.wdColorPink;
    					innertable.Columns[2].Cells[1].Range.Font.Size = NUMBER_FONT_SIZE;
    
    					// Add constants and text for optional data
    					// reference and phone are never in CFS data, and are optional in the Centre Manager database
    					innertable.Rows.Add();
    					Cell cell = innertable.Cell((row + 1), 1);
    					cell.Range.Font.Bold = UNBOLD;
    					cell.Range.Font.Color = WdColor.wdColorBlack;
    					cell.Range.Font.Size = TEXT_FONT_SIZE;
    					cell.Range.Text = "Ref. No.: " + c.Reference;
    					innertable.Rows.Add();
    					cell = innertable.Cell((row + 2), 1);
    					cell.Range.Text = "Tel. No.: " + c.Phone;
    				}
    
    				if (destType == DestinationType.Save || destType == DestinationType.Both)
    				{
    					// Save and close the document
    					// It seems necessary to use a file name without an extension, if the format is specified
    					WdSaveFormat format = (Path.GetExtension(saveFilePath) == ".docx") ? WdSaveFormat.wdFormatDocument : WdSaveFormat.wdFormatDocument97;
    					string saveFile = Path.GetDirectoryName(saveFilePath) + "\\" + Path.GetFileNameWithoutExtension(saveFilePath);
    					newDoc.SaveAs(saveFile,
    						format, missing, missing,
    						false, missing, missing, missing, missing,
    						missing, missing, missing, missing, missing,
    						missing, missing);
    
    					((_Document)newDoc).Close(false, missing, missing);
    				}
    
    				if (destType == DestinationType.Print || destType == DestinationType.Both)
    				{
    					// Print the labels
    					System.Windows.Forms.PrintDialog pDialog = new System.Windows.Forms.PrintDialog();
    					if (pDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
    					{
    						wordApp.ActivePrinter = pDialog.PrinterSettings.PrinterName;
    						newDoc.PrintOut();
    					}
    
    					((_Document)newDoc).Close(false, missing, missing);
    				}
    
    				if (destType == DestinationType.Open)
    				{
    					// Don't close the document, the user is editting it
    					wordApp.Visible = true;
    				}
    			}
    
    			// Does not catch ApplicationException, allow it to be passed to the caller
    			catch (System.Runtime.InteropServices.COMException eCOM)
    			{
    				throw new ApplicationException("Word document create failed", eCOM);
    			}
    		}
    		#endregion
    	}
    }
