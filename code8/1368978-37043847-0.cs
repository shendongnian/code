    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.IO;
    namespace FileSaver
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void panel2_Paint(object sender, PaintEventArgs e)
            {
            }
            private void label1_Click(object sender, EventArgs e)
            {
            }
            //File 004: Save the File in System Temporary path
            private void button2_Click(object sender, EventArgs e)
            {
                if (txtFileContent.Visible == true)
                {
                    SaveFile(Path.GetTempPath());
                }
                else
                    MessageBox.Show("This form saves only text files");
            }
            //File 001: Use File open dialog to get the file name
            private void btn_File_Open_Click(object sender, EventArgs e)
            {
			    this.dlgFileOpen.Filter = "Text Files(*.txt) | *.txt";
			    this.dlgFileOpen.Multiselect = true;
			    if (dlgFileOpen.ShowDialog() == DialogResult.OK)
                {
				    var stBuilder = new StringBuilder();
				
				    foreach (var fileName in dlgFileOPen.SafeFileNames)
				    {
					    if (Path.GetExtension(fileName) == ".txt")
					    {
						    stBuilder.AppendLine(File.ReadAllText(fileName));
					    }
				    }
				
				    txtFileContent.Text = stBuilder.ToString();
                }
            }
            private void txtSelectedFile_TextChanged(object sender, EventArgs e)
            {
            }
            //File 002: Use the Path object to determine the selected file has the
            // required extension.
            private void dlgFileOpen_FileOk(object sender, CancelEventArgs e)
            {
            }
            private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
            {
            }
            private void SaveFile_Click(object sender, EventArgs e)
            {
                //001: Setup the Folder dialog properties before the display
                string selected_path = "";
                dlgFolder.Description = "Select a Folder for Saving the text file";
                dlgFolder.RootFolder = Environment.SpecialFolder.MyComputer;
                //002: Display the dialog for folder selection
                if (dlgFolder.ShowDialog() == DialogResult.OK)
                {
                    selected_path = dlgFolder.SelectedPath;
                    if (string.IsNullOrEmpty(selected_path) == true)
                    {
                        MessageBox.Show("Unable to save. No Folder Selected.");
                        return;
                    }
                }
                //003: Perform the File saving operation. Make sure text file is displayed before saving.
                if (txtFileContent.Visible == true)
                {
                    SaveFile(selected_path);
                }
                else
                    MessageBox.Show("This form saves only text files");
            }
            public void SaveFile(string selected_path)
            {
                string Save_File;
                if (selected_path.Length > 3)
                    Save_File = selected_path + "\\" + txtSaveFile.Text + ".txt";
                else
                    Save_File = selected_path + txtSaveFile.Text + ".txt";
			
			    File.WriteAllText(Save_File, txtFileContent.Text);
                lblSavedLocation.Text = "Text File Saved in " + Save_File;
            }
            private void txtSaveFile_TextChanged(object sender, EventArgs e)
            {
            }
	    }
    }
