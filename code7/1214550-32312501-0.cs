    insertCommand.Parameters.Add("@ID", SqlDbType.Int).Value = (++lastID);
    insertCommand.Parameters.Add("@Subj", SqlDbType.NVarChar, 50).Value = textBox1.Text;
    insertCommand.Parameters.Add("@Pic", SqlDbType.VarBinary).Value = dynamicDotNetTwain1.SaveImageToBytes(lastIndex, Dynamsoft.DotNet.TWAIN.Enums.DWTImageFileFormat.WEBTW_JPG);
    insertCommand.Parameters.Add("@LetDate", SqlDbType.Date).Value = dateTimeSelector1.Value.Value.Date;
    insertCommand.Parameters.Add("@LetTitle", SqlDbType.NText).Value = titleTextBox1.Text;
