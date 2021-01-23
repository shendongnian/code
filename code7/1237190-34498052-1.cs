    List<Education> eduList = aDoc.getAppEdu(aDoc.AppID);
    if (refList.Count < 0)
    {
          appQue.AppendLine("Applicant did not supply Educational Background information." + Environment.NewLine).Bold();
    }
    else
    {
         foreach (Education ed in eduList)
         {
              Novacode.Table tblEdu = doc.AddTable(6, 1);                                      
              tblEdu.AutoFit = AutoFit.Contents;   
              tblEdu.Rows[0].Cells[0].Paragraphs.First().Append("Education").Bold().FontSize(13);  
                tblEdu.Rows[1].Cells[0].Paragraphs.First().Append("* School Name: ");	                       tblEdu.Rows[1].Cells[0].Paragraphs.First().Append(ed.SchoolName).Bold(); ;
            	tblEdu.Rows[2].Cells[0].Paragraphs.First().Append("* City: ");
            	tblEdu.Rows[2].Cells[0].Paragraphs.First().Append(ed.City).Bold();
            	tblEdu.Rows[2].Cells[0].Paragraphs.First().Append("* State: ");
            	tblEdu.Rows[2].Cells[0].Paragraphs.First().Append(ed.EduState).Bold();
            	tblEdu.Rows[2].Cells[0].Paragraphs.First().Append("* Zip: ");
            	tblEdu.Rows[2].Cells[0].Paragraphs.First().Append(ed.Zip).Bold();
            	tblEdu.Rows[3].Cells[0].Paragraphs.First().Append("* From: ");
            	tblEdu.Rows[3].Cells[0].Paragraphs.First().Append(ed.SStartScho).Bold();
            	tblEdu.Rows[3].Cells[0].Paragraphs.First().Append("* To: ");
            	tblEdu.Rows[3].Cells[0].Paragraphs.First().Append(ed.SEndScho).Bold();
            	tblEdu.Rows[4].Cells[0].Paragraphs.First().Append("* Did you graduate? ");
                string grad = "No";
                if (ed.Graduate == true)
                {
                    grad = "Yes";
                }                                                     
                tblEdu.Rows[4].Cells[0].Paragraphs.First().Append(grad).Bold();
                tblEdu.Rows[5].Cells[0].Paragraphs.First().Append("* Diploma/Degree: ");               tblEdu.Rows[5].Cells[0].Paragraphs.First().Append(ed.Degree).Bold();                                                            
                doc.InsertTable(tblEdu);
                appQue = doc.InsertParagraph();
         }
    } 
                          
