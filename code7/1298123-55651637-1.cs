	using System;
	using System.Windows.Forms;
	namespace RichTextBoxFindWithReverse
	{
		public partial class ClsFormMain : Form
		{
			public ClsFormMain()
			{
				InitializeComponent();
				objRichTextBox.SelectionDataIsInteresting += ObjRichTextBox_SelectionDataIsInteresting;
			}
			private void Form1_Load(object sender, EventArgs e)
			{
				objRichTextBox.Text = "cat\ndog\nsnail\nOtter\ntigerelephant\ncatcatcat\ncatcatdog\ncatcatsnail\ncatcatOtter\ncatcattiger\ncatcatelephant\ncatdogcat\ncatdogdog\ncatdogsnail\ncatdogOtter\ncatdogtiger\ncatdogelephant\ncatsnailcat\ncatsnaildog\ncatsnailsnail\ncatsnailOtter\ncatsnailtiger\ncatsnailelephant\ncatOttercat\ncatOtterdog\ncatOttersnail\ncatOtterOtter\ncatOttertiger\ncatOtterelephant\ncattigercat\ncattigerdog\ncattigersnail";
				objButtonFind.Enabled = false;
				objReverse.Enabled = false;
				objCheckBoxMatchCase.Enabled = false;
				objCheckBoxWholeWord.Enabled = false;
			}
			private void ObjTextBoxSearchWord_TextChanged(object sender, EventArgs e)
			{
				if (objRichTextBox.Text.Length > 0 && objTextBoxSearchWord.Text.Length > 0)
				{
					objButtonFind.Enabled = true;
					objReverse.Enabled = true;
					objCheckBoxMatchCase.Enabled = true;
					objCheckBoxWholeWord.Enabled = true;
				}
				else
				{
					objButtonFind.Enabled = false;
					objReverse.Enabled = false;
					objCheckBoxMatchCase.Enabled = false;
					objCheckBoxWholeWord.Enabled = false;
				}
			}
			private void ObjButtonFind_Click(object sender, EventArgs e)
			{
				string options = "";
				if (!objCheckBoxMatchCase.Checked && !objCheckBoxWholeWord.Checked)
				{
					options = "Don't match case.\nMatch on partial word or whole word.";
				}
				else if (!objCheckBoxMatchCase.Checked && objCheckBoxWholeWord.Checked)
				{
					options = "Don't match case.\nMatch on whole word only.";
				}
				else if (objCheckBoxMatchCase.Checked && !objCheckBoxWholeWord.Checked)
				{
					options = "Match case.\nMatch on partial word or whole word.";
				}
				else //(objCheckBoxMatchCase.Checked && objCheckBoxWholeWord.Checked)
				{
					options = "Match case.\nMatch on whole word only.";
				}
				bool found = objRichTextBox.FindTextCustom(objTextBoxSearchWord.Text, objReverse.Checked, objCheckBoxMatchCase.Checked, objCheckBoxWholeWord.Checked);
				if (!found)
				{
					System.Windows.Forms.MessageBox.Show(string.Format("Can't find '{0}'.\n\nYour options:\n\n{1}", objTextBoxSearchWord.Text, options), "RichTextBox Find With Reverse", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			/// <summary>
			/// Display rich text box selection data
			/// </summary>
			/// <param name="sender"></param>
			/// <param name="e"></param>
			private void ObjRichTextBox_SelectionDataIsInteresting(object sender, ClsRichTextBoxSelectionArgs e)
			{
				objTextBoxStartPos.Text = e.SelectionStart.ToString();
			}
		}
	}
	
