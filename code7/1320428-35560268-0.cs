     StringBuilder sb = new StringBuilder("update subjectinfo set subject_name = '");
                sb.Append(textBoxSubjectNameUpdate.Text);
                sb.Append("' , subject_abbreviation = '");
                sb.Append(textBoxSubjectAbbreviationUpdate.Text);
                sb.Append("' where subject_code = '");
                sb.Append(textBoxSubjectCodeUpdate.Text);
                sb.Append("'");
    
    var script  sb.ToString()
