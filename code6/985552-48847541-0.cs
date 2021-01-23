            try
            {
                //Throw error if attachment cell is not selected.
                //make sure user select only single cell
                if (dataGridView1.SelectedCells.Count == 1 && dataGridView1.SelectedCells[0].ColumnIndex == 1)
                {
                    UploadAttachment(dataGridView1.SelectedCells[0]);
                }
                else
                    MessageBox.Show("Select a single cell from Attachment column", "Error uploading file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error uploading file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDownload_Click(object sender, EventArgs e)
        {
            //Throw error if attachment cell is not selected.
            //make sure user select only single cell
            //and the cell have a value in it
            if (dataGridView1.SelectedCells.Count == 1 && dataGridView1.SelectedCells[0].ColumnIndex == 1 && dataGridView1.SelectedCells[0].Value != null)
            {
                DownloadAttachment(dataGridView1.SelectedCells[0]);
            }
            else
                MessageBox.Show("Select a single cell from Attachment column", "Error uploading file", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Throw error if attachment cell is not selected.
            //make sure user select only single cell
            //and the cell have a value in it
            if (dataGridView1.SelectedCells.Count == 1 && dataGridView1.SelectedCells[0].ColumnIndex == 1 && dataGridView1.SelectedCells[0].Value != null)
            {
                DownloadAttachment(dataGridView1.SelectedCells[0]);
            }
            else
                MessageBox.Show("Select a single cell from Attachment column", "Error uploading file", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void UploadAttachment(DataGridViewCell dgvCell)
        {
            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                //Set File dialog properties
                fileDialog.CheckFileExists = true;
                fileDialog.CheckPathExists = true;
                fileDialog.Filter = "All Files|*.*";
                fileDialog.Title = "Select a file";
                fileDialog.Multiselect = false;
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fileInfo = new FileInfo(fileDialog.FileName);
                    byte[] binaryData = File.ReadAllBytes(fileDialog.FileName);
                    dataGridView1.Rows[dgvCell.RowIndex].Cells[1].Value = fileInfo.Name;
                    if (_myAttachments.ContainsKey(dgvCell.RowIndex))
                        _myAttachments[dgvCell.RowIndex] = binaryData;
                    else
                        _myAttachments.Add(dgvCell.RowIndex, binaryData);
                }
            }
        }
        private void DownloadAttachment(DataGridViewCell dgvCell)
        {
            string fileName = Convert.ToString(dgvCell.Value);
            //Return if the cell is empty
            if (fileName == string.Empty)
                return;
            FileInfo fileInfo = new FileInfo(fileName);
            string fileExtension = fileInfo.Extension;
            byte[] byteData = null;
            //show save as dialog
            using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
            {
                //Set Save dialog properties
                saveFileDialog1.Filter = "Files (*" + fileExtension + ")|*" + fileExtension;
                saveFileDialog1.Title = "Save File as";
                saveFileDialog1.CheckPathExists = true;
                saveFileDialog1.FileName = fileName;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    byteData = _myAttachments[dgvCell.RowIndex];
                    File.WriteAllBytes(saveFileDialog1.FileName, byteData);
                }
            }
        }
