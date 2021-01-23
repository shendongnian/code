    using (DocX template = DocX.Load("C:\\Users\\pmolley\\Desktop\\temp1.docx"))
    {
         Novacode.Table tempTable;
         using (DocX template2 = DocX.Load("C:\\Users\\pmolley\\Desktop\\temp2.docx"))
         {
              tempTable = template2.Tables[0];
         }
         Novacode.Table t1 = doc.InsertTable(tempTable);
         t1.InsertRow();
         t1.InsertRow();
         template.Save();
    }
