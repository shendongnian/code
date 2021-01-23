    using (DocX template = DocX.Load("template.docx"))
    {
         Novacode.Table tempTable;
         using (DocX template2 = DocX.Load("template2.docx"))
         {
              tempTable = template2.Tables[0];
         }
         Novacode.Table t1 = doc.InsertTable(tempTable);
         t1.InsertRow();
         t1.InsertRow();
         template.Save();
    }
