                //Your CSV String
            string WhatToWrite =  "row1 column 1, row1 column2, row1 column3, \r\n";
            //Convert your CSV String to byte[]
            byte[] PutWhatToWriteIntoBytes = Encoding.GetEncoding("iso-8859-1").GetBytes(WhatToWrite);
            //Write the byte[] to CSV readable by excel
            string filename = "WhatYouWantToCallYourFile" + ".csv";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", filename.ToString());
            Response.Clear();
            Response.BinaryWrite(PutWhatToWriteIntoBytes);
            Response.End();
