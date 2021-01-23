    private void button2_Click(object sender, EventArgs e)
        {
            int _lastRow = oSheet.Range["A" + oSheet.Rows.Count].End[Microsoft.Office.Interop.Excel.XlDirection.xlUp].Row + 1;
            oSheet.Cells[_lastRow, 1] = txtUsername1.Text;
            oSheet.Cells[_lastRow, 2] = txtWorkName1.Text;
            oSheet.Cells[_lastRow, 3] = cbxManufac.Text;
            oSheet.Cells[_lastRow, 4] = cbxMachType.Text;
            oSheet.Cells[_lastRow, 5] = txtModel.Text;
            oSheet.Cells[_lastRow, 6] = txtSerial.Text;
            oSheet.Cells[_lastRow, 7] = txtCPU.Text;
            oSheet.Cells[_lastRow, 8] = cbxRAM.Text;
            oSheet.Cells[_lastRow, 9] = cbxOS.Text;
            oSheet.Cells[_lastRow, 10] = txtVersion.Text;
            oSheet.Cells[_lastRow, 11] = txtMcstOffice.Text;
            oSheet.Cells[_lastRow, 12] = txtRecomend.Text;
            oSheet.Cells[_lastRow, 13] = txtComments.Text;
        }
