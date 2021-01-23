            DataTable dt = new DataTable();
            dt.Columns.Add("Path");
            dt.Columns.Add("Email");
            DataRow dr = dt.NewRow();
            dr.ItemArray=new object[2]{"C://file1.jpg", "aaa@gmail.com"};
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr.ItemArray=new object[2]{"C://file2.jpg", "aaa@gmail.com"};
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr.ItemArray=new object[2]{"C://file3.jpg", "bbb@gmail.com"};
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr.ItemArray=new object[2]{"C://file4.jpg", "ccc@gmail.com"};
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr.ItemArray=new object[2]{"C://file5.jpg", "bbb@gmail.com"};
            dt.Rows.Add(dr);
        
        
            var grouped=dt.AsEnumerable().GroupBy(x=>x.Field<string>("Email"));
            foreach (var mail in grouped)
            {
                List<string> filesForEmail = new List<string>();
                foreach (var file in mail)
                {
                    filesForEmail.Add(file.Field<string>("Path"));
                }
                
                SendEmailWithAttachments(mail.Key, filesForEmail);
            }
